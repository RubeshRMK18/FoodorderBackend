using Microsoft.EntityFrameworkCore;

namespace FoodorderBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Model.User> Users { get; set; }
    }
}
