using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Models;

namespace RazorPizzeria.Data
{
    public class PastOrderDbContext : DbContext
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public PastOrderDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
