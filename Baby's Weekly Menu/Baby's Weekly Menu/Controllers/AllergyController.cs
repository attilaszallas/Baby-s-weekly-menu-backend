using BabysWeeklyMenu.API.Data;
using BabysWeeklyMenu.API.Models;
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
            if (allergies == null)
            {
                return NotFound();
            }

            return new JsonResult(allergies);
        }

        [HttpGet]
        [Route("/api/allergies/{id}")]
        public async Task<ActionResult> GetAllergy(int id)
        {
            var selectedAllergy = await _context.Allergies.FindAsync(id);
            if (selectedAllergy == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedAllergy);
        }

        [HttpPost]
        public async Task<ActionResult> PostAllergy(Allergy allergy)
        { 
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();

            return new JsonResult(allergy);
        }
    }
}
