

using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Models
{
    public class OdeToFoodDBContext : DbContext
    {
        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
