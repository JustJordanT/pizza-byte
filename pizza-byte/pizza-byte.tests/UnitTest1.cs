using Microsoft.AspNetCore.Mvc;
using Moq;
using pizza_byte.api.Controllers;
using pizza_byte.api.Entities;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.tests;

public class UnitTest1
{
    [Fact]
    public void PostPizza_ValidRequest_CreatesPizzaAndReturnsCorrectResponse()
    {
        // Arrange
        var mockPizzaService = new Mock<IPizzaService>();
        var controller = new PizzaController(mockPizzaService.Object);
        
        var request = new PostPizzaRequest("Margherita", new List<string> { "Cheese", "Jalapeno" }, "Thin", "M");
        
        // Act
        var result = controller.PostPizza(request);

        // Assert
        var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
        
        // Extract anonymous type using reflection
        var response = createdAtResult.Value;
        var idProperty = response.GetType().GetProperty("id");
        var nameProperty = response.GetType().GetProperty("name");
        Assert.NotNull(idProperty);  // Confirm that 'id' property exists

        Guid id = (Guid)idProperty.GetValue(response);
        String name = (String)nameProperty.GetValue(response);
        // Here, you can further assert that 'id' is a non-empty GUID, etc.
        Assert.NotEqual(Guid.Empty, id);
        Assert.Equal("Margherita", name); 
        // Assert.Equal("Thin", response.GetType().GetProperty("crust").GetValue(response));
        // Assert.Equal("M", response.GetType().GetProperty("size").GetValue(response));
        // Assert.Equal(10.99, response.GetType().GetProperty("price").GetValue(response));
        // Assert.Equal(new List<string> { "Cheese", "Jalapeno" }, response.GetType().GetProperty("toppings").GetValue(response));
        // Assert.Equal(DateTime.UtcNow.Date, response.GetType().GetProperty("createdDateTime").GetValue(response));
        // Assert.Equal(DateTime.MinValue.Date, response.GetType().GetProperty("completedDateTime").GetValue(response));
        // Assert.Equal(DateTime.UtcNow.Date, response.GetType().GetProperty("lastModifiedDateTime").GetValue(response));

        mockPizzaService.Verify(service => service.PostPizza(It.IsAny<Pizza>()), Times.Once);
    }}