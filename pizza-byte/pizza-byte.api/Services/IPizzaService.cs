using LanguageExt;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public interface IPizzaService
{
    public Task<PizzaResponse> PostPizza(PostPizzaRequest request);
    public Task<Either<Error, PizzaResponse>> GetPizzaById(Guid? id);
    public Task<Either<Error, PizzaResponse>> DeletePizza(Guid? id);
    public Task<Either<Error, PizzaResponse>> PutPizza(Guid id, PutPizzaRequest request);
}