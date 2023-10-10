using pizza_byte.api.Models;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public class PizzaService : IPizzaService
{
    private static readonly Dictionary<Guid, PizzaByte> _pizzaBytes = new()
    {
        
    };
    
    public void PostPizza(PizzaByte pizza)
    {
       _pizzaBytes.Add(pizza.Id, pizza); 
    }

    public PizzaByte GetPizzaById(Guid id)
    {
        return _pizzaBytes[id];
    }

    public void DeletePizza(Guid id)
    {
        _pizzaBytes.Remove(id);
    }

    public void PutPizza(Guid id, PizzaByte requestPizza)
    {
        var pizza = GetPizzaById(id);
        
        pizza.Name = requestPizza.Name;
        pizza.Toppings = requestPizza.Toppings;
        pizza.Crust = requestPizza.Crust;
        pizza.Size = requestPizza.Size;
        pizza.Price = requestPizza.Price;
        pizza.LastModifiedDateTime = DateTime.UtcNow;
        
        _pizzaBytes[id] = pizza;
    }
    
    public void PutPizza(Guid id, PutPizzaRequest updatedPizza)
    {
        var existingPizza = GetPizzaById(id);  // Fetch existing record

        // Update only the fields you want to change
        existingPizza.Name = updatedPizza.Name;
        existingPizza.LastModifiedDateTime = DateTime.Now;
        existingPizza.Toppings = updatedPizza.Toppings;
        existingPizza.Crust = updatedPizza.Crust;
        existingPizza.Price = updatedPizza.Price;
        existingPizza.Size = updatedPizza.Size;

        // Note: We're not updating existingPizza.CreatedDateTime

        // SaveChanges();  // Save updated record to the database
        // The following is a temporary workaround until we have a database
        _pizzaBytes[id] = existingPizza;
    }
 
}