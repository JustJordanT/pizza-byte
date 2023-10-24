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
        var newPizza = new Pizza(
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
    
    public static Pizza MapToPizzaModel(PizzaResponse request)
    { 
        var model = new Pizza(
            request.Id,
            request.Name,
            request.Toppings,
            request.CreatedDateTime,
            request.CompletedDateTime, 
            request.LastModifiedDateTime,
            request.Crust,
            request.Price,
            request.Size.ToLower());

        return model;
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