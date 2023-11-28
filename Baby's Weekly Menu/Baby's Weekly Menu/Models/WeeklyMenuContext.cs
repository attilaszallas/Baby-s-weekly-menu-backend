using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Models
{
    public class WeeklyMenuContext : DbContext
    {
        public WeeklyMenuContext(DbContextOptions<WeeklyMenuContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
