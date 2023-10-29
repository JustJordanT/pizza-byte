using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pizza_byte.api.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public Guid CartId { get; set; }
    public Cart Cart { get; set; }
    public DateTime CreatedDateTime { get; init; }
    public DateTime LastModifiedDateTime { get; set; }
    public DateTime? CompletedDateTime { get; set; }
    public string? Status { get; set; }
    public string? PaymentType { get; set; }

    public static void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        // builder.Property(o => o.CreatedDateTime)
        //     .IsRequired();
        // builder.Property(o => o.LastModifiedDateTime);
        // builder.Property(o => o.CompletedDateTime);
        // builder.Property(o => o.Status);
        // builder.Property(o => o.PaymentType);

        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);
        builder.HasOne(o => o.Cart)
            .WithOne(c => c.Order)
            .HasForeignKey<Order>(o => o.CartId);
    }
}