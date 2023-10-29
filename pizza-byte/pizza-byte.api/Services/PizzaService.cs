using LanguageExt;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Commons.Wrappers;
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


    public async Task<PizzaResponse> PostPizza(PostPizzaRequest request)
    {
        var pizza = PizzaMapper.PostMapToPizzaModel(request); 
        
        await _dbContext.Pizzas.AddAsync(pizza);
        
        var response = PizzaMapper.MapToPizzaResponse(pizza);
 
        await _dbContext.SaveChangesAsync();
        return response;
    }


    public async Task<Either<Error, PizzaResponse>> GetPizzaById(Guid? id)
    {
        var pizza = await _dbContext.Pizzas
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        if (pizza == null) return new PizzaNotFound();
        
        var response = PizzaMapper.MapToPizzaResponse(pizza); 
        
        return response;
    }

    public async Task<Either<Error, PizzaResponse>> DeletePizza(Guid? id)
    {

        var pizzaResult = await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        
        if (pizzaResult == null) return new PizzaNotFound();
        
        _dbContext.Remove(pizzaResult);
        
        await _dbContext.SaveChangesAsync();

        return PizzaMapper.MapToPizzaResponse(pizzaResult);
    }
    

     public async Task<Either<Error, PizzaResponse>> PutPizza(Guid id, PutPizzaRequest request)
     {
         
         var existingPizza = await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
         
         if (existingPizza == null) return new PizzaNotFound();
            
         PizzaMapper.PutMapToPizzaModel(existingPizza, request);
         
         await _dbContext.SaveChangesAsync();
         
         return PizzaMapper.MapToPizzaResponse(existingPizza);
     }
}