using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    [ApiController]
    public class WeeklyMenuController : ControllerBase
    {
        public JsonResult GetWeeklyMenu()
        {
            return new JsonResult(
                new List<object> { 
                    new { id = 1, Name="Fish"},
                    new { id = 2, Name="Boiled Egg"}
                });
        }
    }
}
