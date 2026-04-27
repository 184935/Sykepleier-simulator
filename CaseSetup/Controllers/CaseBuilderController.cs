using Microsoft.AspNetCore.Mvc;

namespace CaseSetup.Controllers
{
    public class CaseBuilderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }
        public IActionResult Teacher()
        {
            return View();
        }
        public IActionResult AddUserData()
        {
            return View();
        }
    }
}
