using Microsoft.AspNetCore.Mvc;

namespace BusinessSoftware.Client.Controllers
{
    public class OrganizationOnboardController : Controller
    {
        [Route("CreateOrganization")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
