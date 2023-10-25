using LanguageExt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Entities;
using pizza_byte.api.Persistence;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Services;

public class CustomerService : ICustomerService
{
    
    private readonly PizzaDbContext _dbContext;

    public CustomerService(PizzaDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException(nameof(PizzaDbContext));
    }

    public async Task<CustomerResponse> PostCustomer(PostCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = CustomerMapper.PostMapToCustomerModel(request);

        await _dbContext.Customers.AddAsync(customer, cancellationToken);
        
        await _dbContext.SaveChangesAsync(CancellationToken.None);
        return CustomerMapper.MapToCustomerResponse(customer);
    }

    public async Task<Either<Error, Customer>> GetCustomerById(Guid? id, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (customer == null) return new CustomerNotFound();
        return customer;
    }

    public async Task<Either<Error, ActionResult>> PutCustomer(Guid id, PutCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (customer == null) return new CustomerNotFound();
        
        CustomerMapper.PutMapToCustomerModel(customer, request);
        
        return new NoContentResult();
    }
    
    public async Task<Either<Error, ActionResult>> DeleteCustomer(Guid? id, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (customer == null) return new CustomerNotFound();
        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
        
        return new NoContentResult();
    }
}