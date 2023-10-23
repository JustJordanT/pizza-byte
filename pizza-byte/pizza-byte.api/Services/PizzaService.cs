using LanguageExt;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Models;
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


    public void PostPizza(PizzaModel pizza)
    {
        
        _dbContext.Add(pizza);
        _dbContext.SaveChanges();
    }

    // public PizzaModel GetPizzaById(Guid? id)
    // {
    //     if (_dbContext.Pizzas.Any(id => true))
    //     {
    //         throw new NullReferenceException(nameof(id));
    //     }
    //     var pizza = _dbContext.Pizzas.Find(id);
    //     return pizza;
    // }

    public Either<Error, PizzaModel> GetPizzaById(Guid? id)
    {
        var pizza = _dbContext.Pizzas.Find(id);
        if (pizza == null) return new PizzaNotFound();

        return pizza;
    }

    public void DeletePizza(Guid? id)
    {
        var existingPizza = GetPizzaById(id);
        _dbContext.Remove(existingPizza);
        _dbContext.SaveChanges();
    }
    

     public void PutPizza(Guid id, PutPizzaRequest request)
     {
         // Attempt to get the pizza by ID
         var existingPizza = _dbContext.Pizzas.Find(id);

         // var existingPizza = existingPizzaResult.Right(pizza => pizza);
         PizzaMapper.PutMapToPizzaModel(existingPizza, request);
         _dbContext.SaveChanges();
     }
}