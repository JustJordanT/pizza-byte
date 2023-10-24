using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Services;

public interface ICustomerService
{
    Customer PostCustomer(PostCustomerRequest request);
    Customer GetCustomerById(Guid? id);
    void DeleteCustomer(Guid? id);
    public void PutCustomer(Guid id, PutCustomerRequest request);   
}