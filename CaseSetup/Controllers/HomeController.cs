using CaseSetup.Data;
using CaseSetup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SharedLibrary.Models;
using System.Net.Http.Json;

namespace CaseSetup.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            Context = context;
            _httpClientFactory = httpClientFactory;
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
        public void AddUser(int caseid)
        {

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
