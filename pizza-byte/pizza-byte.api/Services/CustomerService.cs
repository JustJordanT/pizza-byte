using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Models;
using pizza_byte.api.Persistence;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public class CustomerService : ICustomerService
{
    
    private readonly PizzaDbContext _dbContext;

    public CustomerService(PizzaDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException(nameof(PizzaDbContext));
    }

    public CustomerModel PostCustomer(PostCustomerRequest request)
    {
        var customer = CustomerMapper.PostMapToCustomerModel(request);
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
        return customer;
    }

    public CustomerModel GetCustomerById(Guid? id)
    {
        var customer = _dbContext.Customers.Find(id);
        if (customer != null) return customer;
        throw new NullReferenceException(nameof(customer));
    }

    public void PutCustomer(Guid id, PutCustomerRequest request)
    {
        var existingCustomer = GetCustomerById(id); // Fetch existing record
        CustomerMapper.PutMapToCustomerModel(existingCustomer, request);
        _dbContext.SaveChanges();
    }
    
    public void DeleteCustomer(Guid? id)
    {
        var customer = _dbContext.Customers.Find(id);
        _dbContext.Remove(customer);
        _dbContext.SaveChanges();
    }
}