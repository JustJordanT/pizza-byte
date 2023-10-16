using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pizza_byte.api.Models;

namespace pizza_byte.api.Persistence.Configurations;

public class PizzaConfigurations : IEntityTypeConfiguration<PizzaModel>
{
    public void Configure(EntityTypeBuilder<PizzaModel> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .HasMaxLength(15);
        builder.Property(p => p.Toppings)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
    }
}