using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Wrappers;
using pizza_byte.api.Entities;

namespace pizza_byte.api.Persistence;

public class PizzaDbContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    

    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>(Pizza.Configure);
        modelBuilder.Entity<Customer>(Customer.Configure);
        modelBuilder.Entity<Order>(Order.Configure);
        modelBuilder.Entity<Cart>(Cart.Configure);
    }
}