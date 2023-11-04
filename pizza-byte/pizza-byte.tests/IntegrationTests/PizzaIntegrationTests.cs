using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Persistence;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.tests.IntegrationTests;

public class PizzaServiceTests
{
    [Fact]
    public async Task PostPizza_SavesPizzaAndReturnsResponse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PizzaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new PizzaDbContext(options);
        var service = new PizzaService(context);
        var request = new PostPizzaRequest
        {
            Name = "John Doe",
            Toppings = new List<string>() { "Cheese", "Pepperoni" },
            Crust = "Thin",
            Size = "l",
            CartId = Guid.NewGuid()
        };

        // Act
        var response = await service.PostPizza(request);

        // Assert
        var savedPizza = await context.Pizzas.FindAsync(response.Id);
        Assert.NotNull(savedPizza);
        Assert.Equal(request.Name, savedPizza.Name);
        Assert.Equal(request.Toppings, savedPizza.Toppings);
        Assert.Equal(request.Crust, savedPizza.Crust);
        Assert.Equal(request.Size, savedPizza.Size);
        Assert.Equal(request.CartId, savedPizza.CartId);
    }
    
    [Fact]
    public async Task GetPizzaById_ReturnsPizzaResponse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PizzaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new PizzaDbContext(options);
        var service = new PizzaService(context);
        var request = new PostPizzaRequest
        {
            Name = "John Doe",
            Toppings = new List<string>() { "Cheese", "Pepperoni" },
            Crust = "Thin",
            Size = "l",
            CartId = Guid.NewGuid()
        };

        var response = await service.PostPizza(request);

        // Act
        var pizzaResponse = await service.GetPizzaById(response.Id);
        var pizza = pizzaResponse.Match<PizzaResponse>(p => p, e => null!);
        // Assert
        Assert.Equal(response.Id, pizza.Id);
        Assert.Equal(response.Name, pizza.Name);
        Assert.Equal(response.Toppings, pizza.Toppings);
        Assert.Equal(response.Crust, pizza.Crust);
        Assert.Equal(response.Size, pizza.Size);
        Assert.Equal(response.CartId, pizza.CartId);
    }
    
    [Fact]
    public async Task DeletePizza_ReturnsPizzaResponse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PizzaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new PizzaDbContext(options);
        var service = new PizzaService(context);
        var request = new PostPizzaRequest
        {
            Name = "John Doe",
            Toppings = new List<string>() { "Cheese", "Pepperoni" },
            Crust = "Thin",
            Size = "l",
            CartId = Guid.NewGuid()
        };

        var response = await service.PostPizza(request);

        // Act
        var pizzaResponse = await service.DeletePizza(response.Id);
        var pizza = pizzaResponse.Match<PizzaResponse>(p => p, e => null!);
        // Assert
        Assert.Equal(response.Id, pizza.Id);
        Assert.Equal(response.Name, pizza.Name);
        Assert.Equal(response.Toppings, pizza.Toppings);
        Assert.Equal(response.Crust, pizza.Crust);
        Assert.Equal(response.Size, pizza.Size);
        Assert.Equal(response.CartId, pizza.CartId);
    }
    
    [Fact]
    public async Task PutPizza_ReturnsPizzaResponse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PizzaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new PizzaDbContext(options);
        var service = new PizzaService(context);
        var request = new PostPizzaRequest
        {
            Name = "John Doe",
            Toppings = new List<string>() { "Cheese", "Pepperoni" },
            Crust = "Thin",
            Size = "l",
            CartId = Guid.NewGuid()
        };

        var response = await service.PostPizza(request);

        // Act
        var pizzaResponse = await service.PutPizza(response.Id, new PutPizzaRequest
        {
            Name = "John Doe",
            Toppings = new List<string>() { "Cheese", "Pepperoni" },
            Crust = "Thin",
            Size = "l",
            CartId = Guid.NewGuid()
        });
        var pizza = pizzaResponse.Match<PizzaResponse>(p => p, e => null!);
        // Assert
        Assert.Equal(response.Id, pizza.Id);
        Assert.Equal(response.Name, pizza.Name);
        Assert.Equal(response.Toppings, pizza.Toppings);
        Assert.Equal(response.Crust, pizza.Crust);
        Assert.Equal(response.Size, pizza.Size);
        Assert.Equal(response.CartId, pizza.CartId);
    }
}