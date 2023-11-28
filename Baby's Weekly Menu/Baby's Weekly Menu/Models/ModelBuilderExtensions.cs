using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Models;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Time=10, MealId=1 },
            new MenuItem { Id = 2, Time = 12, MealId = 2 },
            new MenuItem { Id = 3, Time = 14, MealId = 3 },
            new MenuItem { Id = 4, Time = 16, MealId = 4 },
            new MenuItem { Id = 5, Time = 18, MealId = 5 });
    }
}
