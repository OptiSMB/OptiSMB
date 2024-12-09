using Microsoft.AspNetCore.Mvc;

namespace BusinessSoftware.Client.Controllers
{
    public class OrganizationOnboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
