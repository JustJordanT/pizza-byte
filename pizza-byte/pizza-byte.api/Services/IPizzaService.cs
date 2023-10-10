using pizza_byte.api.Models;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public interface IPizzaService
{
    void PostPizza(PizzaByte pizza);
    PizzaByte GetPizzaById(Guid id);
    void DeletePizza(Guid id);
    public void PutPizza(Guid id, PutPizzaRequest updatedPizza);
}