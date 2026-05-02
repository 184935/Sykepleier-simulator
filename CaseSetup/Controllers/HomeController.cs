using CaseSetup.Data;
using CaseSetup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SharedLibrary.Models;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CaseSetup.Areas.Identity;
using CaseSetup.Areas.Identity.Data;

namespace CaseSetup.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationDbContext context, IHttpClientFactory httpClientFactory, 
            UserManager<User> userManager)
        {
            Context = context;
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Student()
        {
            var client = _httpClientFactory.CreateClient("Rest-API");
            var cases = await client.GetFromJsonAsync<List<Case>>("api/Case/cases");
            return View(cases);
        }
        public async Task<IActionResult> Teacher()
        {
            var client = _httpClientFactory.CreateClient("Rest-API");
            var cases = await client.GetFromJsonAsync<List<Case>>("api/Case/cases");
            return View(cases);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(int caseId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _httpClientFactory.CreateClient("Rest-API");
            var response = await client.PatchAsync(
                $"api/Case/{caseId}/adduser/{userId}", null);

            bool isTeacher = User.FindFirstValue("IsTeacher") == "True";
            var responsecode = response.StatusCode;
            var content = await response.Content.ReadAsStringAsync();
            if (isTeacher)
            {
                return RedirectToAction("Teacher");
            } else
            {
                return RedirectToAction("Student");
            }


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
