using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CaseSetup.Data;
using CaseSetup.Areas.Identity;
using Microsoft.AspNetCore.Identity;
using CaseSetup.Areas.Identity.Data;
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext Context;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO logdto)
        {
            User user = await _userManager.FindByEmailAsync(logdto.Email);

            if (user == null)
            {
                return Unauthorized("Ugyldig brukernavn eller passord");

            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, logdto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Ugyldig brukernavn eller passord");
            }
            var medCase = Context.Cases
                .Include(c => c.Patient)
                .Include(c => c.Vitals)
                .Include(c => c.Goals)
                .Include(c => c.Medications)
                .Include(c => c.Allergies)
                .Include(c => c.Diagnoses)
                .Include(c => c.MedicalHistory)
                .Where(c => c.User == user.Id)
                .FirstOrDefaultAsync();

            if (medCase == null) { return NotFound("Ingen test case lagt til"); }

            return Ok(medCase); 
        }
    }

    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
