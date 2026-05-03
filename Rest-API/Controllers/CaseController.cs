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

        [HttpGet("debriefs")]
        public async Task<IActionResult> GetDebriefs()
        {
            List<Debrief> Debriefs = await Context.Debriefs
                .Include(d => d.Events)
                .Include(d => d.Comments)
                .ToListAsync();

            if (Debriefs.Count == 0)
            {
                return BadRequest("No debriefs");
            }
            return Ok(Debriefs);
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

        // GET api/Case/vitals/id
        [HttpGet("vitals/{id}")]
        public async Task<IActionResult> GetVitals([FromRoute] int id)
        {
            Vitals? vitals = await Context.Vitals.FindAsync(id);
            if (vitals == null)
            {
                return BadRequest("Vitals doesnn't exist");
            }
            return Ok(vitals);
        }

        // GET api/Case/checksim
        [HttpGet("checksim")]
        public async Task<IActionResult> CheckSim()
        {
            Debrief? aktiv = await Context.Debriefs
                .Include(d => d.Events)
                .LastOrDefaultAsync();
            if (aktiv == null || aktiv.Events.Last().Action.Equals("Simulation finished"))
            {
                return BadRequest("No active sim");
            }
            Case? medCase = await Context.Cases
                .Include(c => c.Allergies)
                .Include(c => c.Diagnoses)
                .Include(c => c.MedicalHistory)
                .Include(c => c.Medications)
                .FirstOrDefaultAsync();
            Vitals? tempVitals = await Context.Vitals.LastAsync();

            return Ok(new
            {
                Vitals = tempVitals,
                Case = medCase,
                DebriefId = aktiv.Id
            });

        }

        // PUT api/Case/changevitals
        [HttpPut("changevitals")]
        public async Task<IActionResult> ChangeVitals([FromBody] Vitals newVitals)
        {
            Context.Vitals.Update(newVitals);
            await Context.SaveChangesAsync();
            return Ok(newVitals);

        }

        // POST api/Case/startsim
        [HttpPost("startsim")]
        public async Task<IActionResult> StartSim(int caseId, [FromBody] Event simStart)
        {
            Case? medCase = await Context.Cases
                .Include(c => c.Vitals)
                .FirstOrDefaultAsync(c => c.Id == caseId);
            if (medCase == null)
            {
                return BadRequest("Case doesn't exist");
            }
            Vitals tempVitals = new Vitals(
                medCase.Vitals.OverPressure, medCase.Vitals.UnderPressure,
                medCase.Vitals.Pulse, medCase.Vitals.RespiratoryRate,
                medCase.Vitals.OxygenSaturation, medCase.Vitals.Temperature);
            Context.Vitals.Add(tempVitals);
            //int vitId = Context.SaveChanges();
            Debrief debrief = new Debrief(DateTime.Now, medCase.Id);
            debrief.Events.Add(simStart);
            Context.Debriefs.Add(debrief);
            //int debId = Context.Save
            await Context.SaveChangesAsync();
            return Ok(new
            {
                Vitalsid = tempVitals.Id,
                DebriefId = debrief.Id
            });
        }

        // POST api/Case/stopsim

        [HttpPost("stopsim")]
        public async Task<IActionResult> StopSim([FromBody]Vitals tempVital, [FromBody] Event simEnd, int debId)
        {
            Debrief? deb = await Context.Debriefs.
                Include(d => d.Events)
                .FirstOrDefaultAsync();
            if (deb == null)
            {
                return BadRequest("Debrief doesn't exist");
            }
            deb.Events.Add(simEnd);
            Context.Remove(tempVital);
            await Context.SaveChangesAsync();
            return Ok("Simulation finished");

        }

        // POST api/Case/addevent
        [HttpPost("addevent")]
        public async Task<IActionResult> AddEvent([FromBody] Event newEvent, int debId)
        {
            Debrief? deb = await Context.Debriefs
                .Include(d => d.Events)
                .FirstOrDefaultAsync();
            if (deb == null)
            {
                return BadRequest("Debrief doesn't exist");
            }
            deb.Events.Add(newEvent);
            await Context.SaveChangesAsync();

            return Ok("Event added");
        }

        // POST api/Case/addcomment
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Comment newComment, int debId)
        {
            Debrief? deb = await Context.Debriefs
                .Include(d => d.Comments)
                .FirstOrDefaultAsync();
            if (deb == null)
            {
                return BadRequest("Debrief doesn't exist");
            }
            deb.Comments.Add(newComment);
            await Context.SaveChangesAsync();
            return Ok("Comment added");

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
