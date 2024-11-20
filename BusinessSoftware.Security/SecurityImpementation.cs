using BusinessSoftware.AppContext;
using BusinessSoftware.Common;
using BusinessSoftware.DAL;
using Dapper;

namespace BusinessSoftware.Security
{
    public class SecurityImpementation : IBusinessSecurity
    {
        // This is breaking single responsibilty by adding user table also
        public async Task<SecurityStatusCode> AuthenticateAndAuthorize(bool isLoginPage = false, User? user = null)
        {
            if (BusinessSoftwareContext.IsLoggedIn)
            {
                return SecurityStatusCode.LoginSuccess;
            }

            using var connection = SQLiteHelper.GetConnection("SecurityDB.db");
            connection.Open();

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

            var query = "SELECT * FROM User;";
            var users = connection.Query<User>(query);

            if (users.Count() == 0)
            {
                return SecurityStatusCode.RedirectToSignup;
            }

            return SecurityStatusCode.RedirectToLogin;
        }
    }
}