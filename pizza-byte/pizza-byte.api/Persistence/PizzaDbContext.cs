using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Entities;

namespace pizza_byte.api.Persistence;

public class PizzaDbContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;

    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaDbContext).Assembly);
    }
}