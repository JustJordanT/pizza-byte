using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Models;

namespace pizza_byte.api.Persistence;

public class PizzaDbContext : DbContext
{
    public DbSet<PizzaModel> Pizzas { get; set; } = null!;

    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaDbContext).Assembly);
    }
}