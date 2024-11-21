
using BusinessSoftware.Common;

namespace BusinessSoftware.Security
{
    public interface IBusinessSecurity
    {
        Task<SecurityStatusCode> AuthenticateOrCreateUser(User user, bool isLoginPage = false);
    }
}