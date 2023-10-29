using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Cart;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Services;

public interface ICartService
{
    public Task<CartResponse> PostCart(PostCartRequest request, CancellationToken cancellationToken);

    public Task<Either<Error, Cart>> GetCartById(Guid? id, CancellationToken cancellationToken);
    // Task<Either<Error, ActionResult>> DeleteCustomer(Guid? id, CancellationToken cancellationToken);
    // public Task<Either<Error, ActionResult>> PutCustomer(Guid id, PutCustomerRequest request, CancellationToken cancellationToken);   
}