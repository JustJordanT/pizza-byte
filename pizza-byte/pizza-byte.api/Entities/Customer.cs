using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pizza_byte.api.Entities;

public class Customer
{
   [Key]
   public Guid Id { get; set; } = Guid.NewGuid();

   [Required]
   [MaxLength(50)]
   // TODO: Add unique constraint
   // [Index(nameof(CustomerModel.Username), IsUnique = true)]
   public string Username { get; set; }
   [Required]
   [MaxLength(128)]
   public string PasswordHash { get; set; }

   [MaxLength(64)]
   public string Salt { get; set; }

   [Required]
   [MaxLength(50)]
   public string Email { get; set; }

   [MaxLength(15)]
   public string PhoneNumber { get; set; }

   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   
   public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;

   // TODO : Needs to be added when OrderModel is created
   // Navigation properties for related entities
   public virtual ICollection<Order> Orders { get; set; }

   public Customer()
   {
      
   }

   public Customer(string username, string passwordHash, string salt, string email, string phoneNumber)
   {
      Username = username;
      PasswordHash = passwordHash;
      Salt = salt;
      Email = email;
      PhoneNumber = phoneNumber;
   }
   
   public static void Configure(EntityTypeBuilder<Customer> builder)
   {
      builder.ToTable("Customers");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Username)
         .IsRequired()
         .HasMaxLength(50);
      builder.Property(c => c.PasswordHash)
         .IsRequired()
         .HasMaxLength(128);
      builder.Property(c => c.Salt)
         .IsRequired()
         .HasMaxLength(64);
      builder.Property(c => c.Email)
         .IsRequired()
         .HasMaxLength(50);
      builder.Property(c => c.PhoneNumber)
         .IsRequired()
         .HasMaxLength(20);
      builder.Property(c => c.CreatedAt)
         .IsRequired();
      builder.Property(c => c.LastModifiedDateTime)
         .IsRequired();
      builder.HasMany(c => c.Orders)
         .WithOne(o => o.Customer!)
         .HasForeignKey(o => o.CustomerId);
   }
}


   