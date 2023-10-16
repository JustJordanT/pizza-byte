using Microsoft.EntityFrameworkCore;
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

    public PizzaModel GetPizzaById(Guid? id)
    {
        var pizza = _dbContext.Pizzas.Find(id);
        return pizza;
    }

    public void DeletePizza(Guid? id)
    {
        var pizza = _dbContext.Pizzas.Find(id);
        _dbContext.Remove(pizza);
        _dbContext.SaveChanges();
    }

    public void PutPizza(Guid id, PutPizzaRequest request)
    {
        var existingPizza = GetPizzaById(id); // Fetch existing record
        PizzaMapper.PutMapToPizzaModel(existingPizza, request);
        _dbContext.SaveChanges();
    }

}