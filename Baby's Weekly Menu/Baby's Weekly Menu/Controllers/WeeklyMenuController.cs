using BabysWeeklyMenu.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers
{
    [ApiController]
    public class WeeklyMenuController : ControllerBase
    {
        private readonly WeeklyMenuContext _context;

        public WeeklyMenuController(WeeklyMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/allergies")]
        public async Task<ActionResult> GetAllAllergies()
        {
            var allergiesList = await _context.Allergies.ToListAsync();
            return new JsonResult(allergiesList);
        }

        [HttpGet]
        [Route("/api/ingredients")]
        public async Task<ActionResult> GetAllIngredients()
        {
            var ingredientsList = await _context.Ingredients.ToListAsync();
            return new JsonResult(ingredientsList);
        }

        [HttpGet]
        [Route("/api/dishes")]
        public async Task<ActionResult> GetAllMeals()
        {
            var dishesList = await _context.Dishes.ToListAsync();
            return new JsonResult(dishesList);
        }

        [HttpGet]
        [Route("/api/meals")]
        public async Task<ActionResult> GetWeeklyMenu()
        {
            var mealsList = await _context.Meals.ToListAsync();
            return new JsonResult(mealsList);
        }
    }
}
