using CaseSetup.Data;
using CaseSetup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SharedLibrary.Models;

namespace CaseSetup.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext Context;

        public HomeController(ApplicationDbContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Student()
        {
            List<Case> Cases = Context.Cases
                .Include(c => c.Patient)
                .Include(c => c.Vitals)
                .ToList();
            Context.Cases.Load();
            return View(Cases);
        }
        public IActionResult Teacher()
        {
            List<Case> Cases = Context.Cases
                .Include(c => c.Patient)
                .Include(c => c.Vitals)
                .ToList();
            Context.Cases.Load();
            return View(Cases);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
