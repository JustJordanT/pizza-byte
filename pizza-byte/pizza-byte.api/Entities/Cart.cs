using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pizza_byte.api.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public decimal Total { get; set; }
    public int Quantity { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public bool IsActive { get; set; } = true;
    public Order Order { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public static void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.Customer)
            .WithMany(customer => customer.Carts)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.Order)
            .WithOne(o => o.Cart)
            .HasForeignKey<Order>(o => o.CartId);  // Adjusted line
    }
}