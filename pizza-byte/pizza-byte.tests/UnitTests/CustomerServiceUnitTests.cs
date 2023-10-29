using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Persistence;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;
using Xunit.Abstractions;

namespace pizza_byte.tests.UnitTests;

public class CustomerServiceUnitTests
{
    private readonly ITestOutputHelper _output;

    public CustomerServiceUnitTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public async Task PostCustomer_SavesCustomerAndReturnsResponse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PizzaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new PizzaDbContext(options);
        var service = new CustomerService(context);
        var request = new PostCustomerRequest
        {
            UserName = "John Doe",
            Email = "john@gmail.com",
            PhoneNumber = "888-999-9898",
            Password = "password123!!"
        };
        
        // Act
        var response = await service.PostCustomer(request, new CancellationToken());
        
        // Assert
        var savedCustomer = await context.Customers.FindAsync(response.Id);
        Assert.NotNull(savedCustomer);
        Assert.Equal(request.UserName, savedCustomer.UserName);
        Assert.Equal(request.Email, savedCustomer.Email);
        Assert.Equal(request.PhoneNumber, savedCustomer.PhoneNumber);
        //TODO - Fix this test should do some logic to handle the password hashing and salting
        // Assert.Equal(request.Password, savedCustomer.Password);
    }

    [Fact]
    public async Task GetCustomerById_ReturnsCustomerResponse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PizzaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new PizzaDbContext(options);
        var service = new CustomerService(context);
        var request = new PostCustomerRequest
        {
            UserName = "John Doe",
            Email = "john@gmail.com",
            PhoneNumber = "555-555-5555",
            Password = "password123!!"
        };
        
        var response = await service.PostCustomer(request, new CancellationToken());
        
        // Act
        var customerResponse = await service.GetCustomerById(response.Id, new CancellationToken());
        var customer = customerResponse.Match(
            Right: x => x,
            Left: x => throw new Exception("Customer not found")
        );
        
        // Assert
        Assert.NotNull(customer);
        // Assert.Equal(request.UserName, customer.UserName);
        Assert.Equal("jimmy", customer.UserName);
        Assert.Equal(request.Email, customer.Email);
        Assert.Equal(request.PhoneNumber, customer.PhoneNumber);
        //TODO - Fix this test should do some logic to handle the password hashing and salting
        // Assert.Equal(request.Password, customer.Password);
    }
}