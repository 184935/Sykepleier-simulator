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
        [HttpPatch("{caseId}/adduser/{userId}")]
        public async Task<IActionResult> AddUser([FromRoute]int caseId, [FromRoute]string userId)
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

            User? user = Context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();
            if (user == null || medCase == null) { return BadRequest(); }
            medCase.User = user.Id;
            Context.Update(medCase);
            await Context.SaveChangesAsync();
            return Ok();

        }

        // GET api/<CaseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Context.Cases.Load();
            Case? medCase = Context.Cases
                .Include(c => c.Patient)
                .Include(c => c.Vitals)
                .Include(c => c.Medications)
                .Include(c => c.Allergies)
                .Include(c => c.Diagnoses)
                .FirstOrDefault(c => c.Id == id);
            if (medCase != null)
            {
                return Ok(medCase);
            } else {

                return BadRequest();
            }
            
        }

        // POST api/<CaseController>
        [HttpPost("addvitals")]
        public async Task<IActionResult> AddVitals([FromBody] Vitals vitals)
        {
            Context.Vitals.Add(vitals);
            int id = Context.SaveChanges();
            return Ok(id);

        }

        // PUT api/Case/changevitals
        [HttpPut("changevitals")]
        public async Task<IActionResult> ChangeVitals([FromBody] Vitals newVitals)
        {
            Context.Vitals.Update(newVitals);
            await Context.SaveChangesAsync();
            return Ok(newVitals);

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
