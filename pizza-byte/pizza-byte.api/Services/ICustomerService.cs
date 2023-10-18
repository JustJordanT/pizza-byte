using pizza_byte.api.Models;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Services;

public interface ICustomerService
{
    CustomerModel PostCustomer(PostCustomerRequest request);
    CustomerModel GetCustomerById(Guid? id);
    void DeleteCustomer(Guid? id);
    public void PutCustomer(Guid id, PutCustomerRequest request);   
}