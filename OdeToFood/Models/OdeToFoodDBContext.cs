

using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Models
{
    //Entity Framework, which is an ORM (Object Relational Mapping) it is a framework that allows database tables to be created from c# classes.  
    public class OdeToFoodDBContext : DbContext
    {
        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
