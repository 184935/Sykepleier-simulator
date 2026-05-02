using Microsoft.AspNetCore.Mvc;
using CaseSetup.Data;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;

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
        public void Patch(int caseId, string userId)
        {
            Context.Cases.Load();

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
