using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    [ApiController]
    public class WeeklyMenuController : ControllerBase
    {
        [HttpGet]
        [Route("/api/weekly")]
        public JsonResult GetWeeklyMenu()
        {
            return new JsonResult(
                new List<object> { 
                    new { id = 1, Time = 10, Name="Fish"},
                    new { id = 2, Time = 11, Name="Boiled Egg"}
                });
        }
    }
}
