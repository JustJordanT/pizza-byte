using LanguageExt;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Entities;
using pizza_byte.api.Persistence;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public class PizzaService : IPizzaService
{
    private readonly  PizzaDbContext _dbContext;

    public PizzaService(PizzaDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException(nameof(PizzaDbContext));
    }


    public void PostPizza(Pizza pizza)
    {
        
        _dbContext.Add(pizza);
        _dbContext.SaveChanges();
    }


    public Either<Error, PizzaResponse> GetPizzaById(Guid? id)
    {
        var pizza = _dbContext.Pizzas.AsNoTracking().FirstOrDefault(p => p.Id == id);
        if (pizza == null) return new PizzaNotFound();
        
        var response = PizzaMapper.MapToPizzaResponse(pizza); 
        
        return response;
    }

    public Either<Error, PizzaResponse> DeletePizza(Guid? id)
    {

        var pizzaResult = _dbContext.Pizzas.FirstOrDefault(p => p.Id == id);
        
        if (pizzaResult == null) return new PizzaNotFound();
        
        _dbContext.Remove(pizzaResult);
        
        _dbContext.SaveChanges();

        return PizzaMapper.MapToPizzaResponse(pizzaResult);
    }
    

     public Either<Error, PizzaResponse> PutPizza(Guid id, PutPizzaRequest request)
     {
         
         var existingPizza = _dbContext.Pizzas.FirstOrDefault(p => p.Id == id);
         
         if (existingPizza == null) return new PizzaNotFound();
            
         PizzaMapper.PutMapToPizzaModel(existingPizza, request);
         
         _dbContext.SaveChanges();
         
         return PizzaMapper.MapToPizzaResponse(existingPizza);
     }
}