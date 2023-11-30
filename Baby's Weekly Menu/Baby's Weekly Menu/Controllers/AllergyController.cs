using BabysWeeklyMenu.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly WeeklyMenuContext _context;

        public AllergyController(WeeklyMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/allergies")]
        public async Task<ActionResult> GetAllAllergies()
        {
            var allergies = await _context.Allergies.ToListAsync();
            return new JsonResult(allergies);
        }

        [HttpGet]
        [Route("/api/allergies/{id}")]
        public async Task<ActionResult> GetAllergy(int id)
        {
            var selectedAllergy = await _context.Allergies.FindAsync(id);
            return new JsonResult(selectedAllergy);
        }
    }
}
