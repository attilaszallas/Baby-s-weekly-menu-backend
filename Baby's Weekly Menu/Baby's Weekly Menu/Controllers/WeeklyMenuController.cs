using BabysWeeklyMenu.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("/api/ingredients")]
        public async Task<ActionResult> GetAllIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            return new JsonResult(ingredients);
        }

        [HttpGet]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult> GetIngredient(int id)
        {
            var selectedIngredient = await _context.Ingredients.FindAsync(id);
            return new JsonResult(selectedIngredient);
        }

        [HttpGet]
        [Route("/api/dishes")]
        public async Task<ActionResult> GetAllDishes()
        {
            var dishes = await _context.Dishes.ToListAsync();
            return new JsonResult(dishes);
        }

        [HttpGet]
        [Route("/api/dish/{id}")]
        public async Task<ActionResult> GetDish(int id)
        {
            var selectedDish = await _context.Dishes.FindAsync(id);
            return new JsonResult(selectedDish);
        }

        [HttpGet]
        [Route("/api/meals")]
        public async Task<ActionResult> GetAllMeals()
        {
            var meals = await _context.Meals.ToListAsync();
            return new JsonResult(meals);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetMeal(int id)
        {
            var selectedMeals = await _context.Meals.FindAsync(id);
            return new JsonResult(selectedMeals);
        }
    }
}
