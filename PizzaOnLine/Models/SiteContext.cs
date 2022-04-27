using System.Data.Entity;

namespace PizzaOnLine.Models
{
    public class SiteContext:DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
