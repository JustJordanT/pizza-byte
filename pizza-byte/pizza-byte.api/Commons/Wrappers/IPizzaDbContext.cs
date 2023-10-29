using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Entities;

namespace pizza_byte.api.Commons.Wrappers;

public interface IPizzaDbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; } 
    public DbSet<Order> Orders { get; set; }
    public DbSet<Cart> Carts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Remove(Pizza pizzaResult);
}