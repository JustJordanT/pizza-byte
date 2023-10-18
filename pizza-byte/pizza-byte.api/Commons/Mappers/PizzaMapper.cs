using pizza_byte.api.Models;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Commons.Mappers;

public static class PizzaMapper
{
    
    public static PizzaModel PostMapToPizzaModel(PostPizzaRequest request)
    { 
        var newPizza = new PizzaModel(
            Guid.NewGuid(),
            request.Name,
            request.Toppings,
            DateTime.UtcNow,
            DateTime.MinValue, 
            DateTime.UtcNow,
            request.Crust,
            Commons.Logic.Utils.UpdatePriceBasedOnSize(request.Size.ToLower()),
            request.Size.ToLower());

        return newPizza;
    }
    
    public static PizzaModel PutMapToPizzaModel(PizzaModel pizza, PutPizzaRequest request)
    {
        pizza.Name = request.Name;
        pizza.LastModifiedDateTime = DateTime.UtcNow;
        pizza.Toppings = request.Toppings;
        pizza.Crust = request.Crust;
        pizza.Size = request.Size;
        pizza.Price = Commons.Logic.Utils.UpdatePriceBasedOnSize(request.Size?.ToLower() ?? throw new InvalidOperationException());
        
        return pizza;
    }
    
    public static PizzaResponse MapToPizzaResponse(PizzaModel pizza)
    {
        var response = new PizzaResponse(
            pizza.Id,
            pizza.Name,
            pizza.CreatedDateTime,
            pizza.CompletedDateTime,
            pizza.LastModifiedDateTime,
            pizza.Toppings,
            pizza.Crust,
            pizza.Size,
            pizza.Price);
        
        return response;
    }
}