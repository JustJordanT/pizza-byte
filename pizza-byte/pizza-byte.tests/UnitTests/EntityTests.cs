using pizza_byte.api.Entities;

namespace pizza_byte.tests.UnitTests;

public class EntityTests
{
    [Fact]
    public void Customer_HasProperties()
    {
        // Arrange
        var customer = new Customer();
        var date = DateTime.Now;
        var password = "password123!!";
        var id = new Guid("018b8776-b703-7d2c-8e83-dd1f8f701ccb");

        // Act
        customer.UserName = "John Doe";
        customer.Email = "John@gmail.com";
        customer.PhoneNumber = "555-555-5555";
        customer.Id = id;
        customer.CreatedAt = date;
        customer.LastModifiedDateTime = date;
        // This is just checking that the password is being set to the salt;
        // since we are not actually hashing the password; this is validating 
        customer.Salt = password;
        customer.PasswordHash = password;
        
        // Assert
        Assert.Equal("John Doe", customer.UserName);
        Assert.Equal("John@gmail.com", customer.Email);
        Assert.Equal(id, customer.Id);
        Assert.Equal(date, customer.CreatedAt);
        Assert.Equal(date, customer.LastModifiedDateTime);
        Assert.Equal(password, customer.Salt);
        Assert.Equal(password, customer.PasswordHash);
    }
}