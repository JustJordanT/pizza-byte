using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pizza_byte.api.Entities;

public class Pizza
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public List<string>? Toppings { get; set; } = null!;
    public DateTime CreatedDateTime { get; init;  } = DateTime.Now;
    public DateTime? CompletedDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; } = DateTime.Now;
    public string? Crust { get; set; }
    public decimal Price { get; set; }
    public string? Size { get; set; }
    public Guid CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    
    
    public Pizza()
    {
        
    }
    
    // public Pizza(
    //     Guid id,
    //     string? name,
    //     List<string>? toppings,
    //     DateTime createdDateTime,
    //     DateTime? completedDateTime,
    //     DateTime lastModifiedDateTime,
    //     string? crust,
    //     decimal price,
    //     string? size)
    // {
    //     Id = id;
    //     Name = name;
    //     Toppings = toppings;
    //     CreatedDateTime = createdDateTime;
    //     CompletedDateTime = completedDateTime;
    //     LastModifiedDateTime = lastModifiedDateTime;
    //     Crust = crust;
    //     Price = price;
    //     Size = size;
    // }
    
    public static void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .HasMaxLength(15);
        builder.Property(p => p.Toppings)
            .HasConversion(
                v => string.Join(',', v!),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
        builder.HasOne(p => p.Cart)
            .WithMany(c => c.Pizzas)
            .HasForeignKey(p => p.CartId);
        
    }
}

