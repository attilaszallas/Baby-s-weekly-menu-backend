using BabysWeeklyMenu.API.Models;
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
        [Route("/api/weekly")]
        public async Task<ActionResult> GetWeeklyMenu()
        {
            var menuItemsList = await _context.MenuItems.ToListAsync();
            return new JsonResult(menuItemsList);
        }
    }
}
