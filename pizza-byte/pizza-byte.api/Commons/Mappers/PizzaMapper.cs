using LanguageExt;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Entities;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Commons.Mappers;

public static class PizzaMapper
{
    
    public static Pizza PostMapToPizzaModel(PostPizzaRequest request)
    { 
        return new Pizza
        {
            Name = request.Name,
            Toppings = request.Toppings,
            CreatedDateTime = DateTime.UtcNow,
            CompletedDateTime = default,
            LastModifiedDateTime = DateTime.UtcNow,
            Crust = request.Crust,
            Price = Commons.Logic.Utils.UpdatePriceBasedOnSize(request.Size?.ToLower() ?? throw new InvalidOperationException()),
            Size = request.Size?.ToLower() ?? throw new InvalidOperationException(),
            CartId = request.CartId,
            Cart = null!
        };
    }
    
    public static Pizza MapToPizzaModel(PizzaResponse request)
    {
        return  new Pizza
        {
            Name = request.Name,
            Toppings = request.Toppings,
            CreatedDateTime = request.CreatedDateTime,
            CompletedDateTime = request.CompletedDateTime,
            LastModifiedDateTime = request.LastModifiedDateTime,
            Crust = request.Crust,
            Price = request.Price,
            Size = request.Size,
            CartId = request.CartId
        };
    }
    
    public static void PutMapToPizzaModel(Pizza pizza, PutPizzaRequest request)
    {
        pizza.Name = request.Name;
        pizza.LastModifiedDateTime = DateTime.UtcNow;
        pizza.Toppings = request.Toppings;
        pizza.Crust = request.Crust;
        pizza.Size = request.Size;
        pizza.Price = Commons.Logic.Utils.UpdatePriceBasedOnSize(request.Size?.ToLower() ?? throw new InvalidOperationException());
        
    }
    
    public static PizzaResponse MapToPizzaResponse(Pizza pizza)
    {
        var response = new PizzaResponse();

        response.Id = pizza.Id;
        response.Name = pizza.Name;
        response.CreatedDateTime = pizza.CreatedDateTime;
        response.CompletedDateTime = pizza.CompletedDateTime;
        response.Toppings = pizza.Toppings;
        response.Crust = pizza.Crust;
        response.Size = pizza.Size;
        response.Price = pizza.Price;
        
        return response;
    }
}