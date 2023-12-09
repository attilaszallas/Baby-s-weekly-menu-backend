using BabysWeeklyMenu.API.Data;
using BabysWeeklyMenu.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly WeeklyMenuContext _context;

        public IngredientController(WeeklyMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/ingredients")]
        public async Task<ActionResult> GetAllIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            if (ingredients == null)
            {
                return NotFound();
            }

            return new JsonResult(ingredients);
        }

        [HttpGet]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult> GetIngredient(int id)
        {
            var selectedIngredient = await _context.Ingredients.FindAsync(id);
            if (selectedIngredient == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedIngredient);
        }

        [HttpPost]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult<Ingredient>> PostMeal(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return new JsonResult(ingredient);
        }
    }
}
