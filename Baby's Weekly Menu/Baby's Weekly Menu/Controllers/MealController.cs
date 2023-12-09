using BabysWeeklyMenu.API.Data;
using BabysWeeklyMenu.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly WeeklyMenuContext _context;

        public MealController(WeeklyMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/meals")]
        public async Task<ActionResult> GetAllMeals()
        {
            var meals = await _context.Meals.ToListAsync();
            if (meals == null)
            {
                return NotFound();
            }

            return new JsonResult(meals);
        }

        [HttpGet]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult> GetMeal(int id)
        {
            var selectedMeals = await _context.Meals.FindAsync(id);
            if (selectedMeals == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedMeals);
        }

        [HttpPost]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return new JsonResult(meal);
        }

        [HttpDelete]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult> DeleteMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);

            if (meal == null) { return NotFound(); }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return new JsonResult(meal);
        }
    }
}
