using BabysWeeklyMenu.API.Data;
using BabysWeeklyMenu.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly WeeklyMenuContext _context;

        public DishController(WeeklyMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/dishes")]
        public async Task<ActionResult> GetAllDishes()
        {
            var dishes = await _context.Dishes.ToListAsync();
            if (dishes == null)
            {
                return NotFound();
            }

            return new JsonResult(dishes);
        }

        [HttpGet]
        [Route("/api/dish/{id}")]
        public async Task<ActionResult> GetDish(int id)
        {
            var selectedDish = await _context.Dishes.FindAsync(id);
            if (selectedDish == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedDish);
        }

        [HttpPost]
        [Route("/api/dish/{id}")]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return new JsonResult(dish);
        }
    }
}
