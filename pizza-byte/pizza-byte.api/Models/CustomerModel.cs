using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace pizza_byte.api.Models;

public class CustomerModel
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
   // public virtual ICollection<Order> Orders { get; set; }

   public CustomerModel()
   {
      
   }

   public CustomerModel(string username, string passwordHash, string salt, string email, string phoneNumber)
   {
      Username = username;
      PasswordHash = passwordHash;
      Salt = salt;
      Email = email;
      PhoneNumber = phoneNumber;
   }
}


   