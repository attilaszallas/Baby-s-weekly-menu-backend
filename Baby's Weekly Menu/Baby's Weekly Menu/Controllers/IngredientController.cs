using BabysWeeklyMenu.API.Data;
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
            return new JsonResult(ingredients);
        }

        [HttpGet]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult> GetIngredient(int id)
        {
            var selectedIngredient = await _context.Ingredients.FindAsync(id);
            return new JsonResult(selectedIngredient);
        }
    }
}
