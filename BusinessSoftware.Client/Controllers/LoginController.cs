using Microsoft.AspNetCore.Mvc;

namespace BusinessSoftware.Client.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
