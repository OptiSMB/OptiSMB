using BusinessSoftware.DAL;
using Dapper;

namespace BusinessSoftware.Security
{
    public class SecurityImpementation : IBusinessSecurity
    {
        public void AuthenticateAndAuthorize()
        {
            using var connection = SQLiteHelper.GetConnection("SecurityDB.db");
            connection.Open();

            var query = "SELECT * FROM User;";
            var users =  connection.Query<User>(query);
        }
    }
}