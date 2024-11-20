
using BusinessSoftware.Common;

namespace BusinessSoftware.Security
{
    public interface IBusinessSecurity
    {
        Task<SecurityStatusCode> AuthenticateAndAuthorize(bool isLoginPage = false, User user = null);
    }
}