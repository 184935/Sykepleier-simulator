using Microsoft.AspNetCore.Mvc;
using CaseSetup.Data;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using CaseSetup.Areas.Identity.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {

        private readonly ApplicationDbContext Context;

        public CaseController(ApplicationDbContext context)
        {
            Context = context;
        }


        [HttpGet("cases")]
        public IEnumerable<Case> GetCases()
        {
            Context.Cases.Load();
            List<Case> Cases = Context.Cases
                .Include(c => c.Patient)
                .Include(c => c.Vitals)
                .Include(c => c.Medications)
                .Include(c => c.Allergies)
                .Include(c => c.Diagnoses)
                .ToList();
            
            return Cases;
        }

        // GET: api/<CaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // PATCH api/<CaseController>
        [HttpPatch]
        public IActionResult Patch(int caseId, string userId)
        {
            Context.Cases.Load();
            Context.Users.Load();
            Case medCase = (Case)Context.Cases
                    .Include(c => c.Patient)
                    .Include(c => c.Vitals)
                    .Include(c => c.Medications)
                    .Include(c => c.Allergies)
                    .Include(c => c.Diagnoses)
                    .Where(c => c.Id == caseId).First();

            User user = (User)Context.Users
                .Where(u => u.Id == userId);
            if (user == null || medCase == null) { return BadRequest(); }
            medCase.User = user.Id;
            Context.Update(medCase);
            Context.SaveChanges();
            return Ok();

        }

        // GET api/<CaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
