using LanguageExt;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public interface IPizzaService
{
    void PostPizza(Pizza pizza);
    Either<Error, PizzaResponse> GetPizzaById(Guid? id);
    Either<Error, PizzaResponse> DeletePizza(Guid? id);
    public Either<Error, PizzaResponse> PutPizza(Guid id, PutPizzaRequest request);
}