using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSoftware.Client.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUpController
        [Route("SignUp")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
