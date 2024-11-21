using BusinessSoftware.AppContext;
using BusinessSoftware.Common;
using BusinessSoftware.DAL;
using Dapper;

namespace BusinessSoftware.Security
{
    public class SecurityImpementation : IBusinessSecurity
    {
        public async Task<SecurityStatusCode> AuthenticateAndAuthorize(bool isLoginPage = false, User user = null)
        {
            if (BusinessSoftwareContext.IsLoggedIn)
            {
                return SecurityStatusCode.LoginSuccess;
            }
            try
            {
                using var connection = SQLiteHelper.GetConnection("SecurityDB.db");
                connection.Open();

                await CreateUserTableIfNotExistDuringLogin(isLoginPage, connection);

                var query = "SELECT * FROM User;";
                var users = await connection.QueryAsync<User>(query);

                if (users.Count() == 0)
                {
                    return await InsertNewUserAsync(user, connection);
                }

                var existingUser = users.Where(a => a.UserName == user.UserName && a.Password == user.Password);
                if (existingUser.Count() == 0)
                {
                    return await InsertNewUserAsync(user, connection);
                }

                UpdateBusinessContextAfterLogin(existingUser.First());

                return SecurityStatusCode.LoginSuccess;
            }
            catch (Exception)
            {
                return SecurityStatusCode.LoginFailed;
            }
        }

        private async Task CreateUserTableIfNotExistDuringLogin(bool isLoginPage, System.Data.IDbConnection connection)
        {
            if (isLoginPage)
            {
                string createUserTableQuery = @"
                CREATE TABLE IF NOT EXISTS User (
                    UserName    TEXT,
                    Password	TEXT NOT NULL,
	                PRIMARY KEY(UserName)
                );";
                await connection.ExecuteAsync(createUserTableQuery);
            }
        }

        private async Task<SecurityStatusCode> InsertNewUserAsync(User user, System.Data.IDbConnection connection)
        {
            var insertUserQuery = "INSERT INTO User (UserName, Password) VALUES (@UserName, @Password);";

            // Replace these values with actual data
            var userName = user.UserName;
            var password = user.Password;

            // Execute the query
            await connection.ExecuteAsync(insertUserQuery, new { UserName = userName, Password = password });

            UpdateBusinessContextAfterLogin(user);

            return SecurityStatusCode.LoginSuccess;
        }

        private static void UpdateBusinessContextAfterLogin(User user)
        {
            BusinessSoftwareContext.User = user;
            BusinessSoftwareContext.IsLoggedIn = true;
            BusinessSoftwareContext.LastLoggedIn = DateTime.Now;
        }
    }
}