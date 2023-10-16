using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pizza_byte.api.Models;

namespace pizza_byte.api.Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<CustomerModel>
{
    public void Configure(EntityTypeBuilder<CustomerModel> builder)
    {
        builder.HasKey(c => c.Id);
    }
}