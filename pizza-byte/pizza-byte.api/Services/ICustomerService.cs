using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Services;

public interface ICustomerService
{
    public Task<CustomerResponse> PostCustomer(PostCustomerRequest request, CancellationToken cancellationToken);
    public Task<Either<Error, CustomerResponse>> GetCustomerById(Guid? id, CancellationToken cancellationToken);
    Task<Either<Error, ActionResult>> DeleteCustomer(Guid? id, CancellationToken cancellationToken);
    public Task<Either<Error, ActionResult>> PutCustomer(Guid id, PutCustomerRequest request, CancellationToken cancellationToken);   
}