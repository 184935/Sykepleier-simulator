using CaseSetup.Data;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace CaseSetup.Controllers
{
    public class CaseBuilderController : Controller
    {
        private readonly ApplicationDbContext Context;

        public CaseBuilderController(ApplicationDbContext context)
        {
            Context = context;
        }
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
