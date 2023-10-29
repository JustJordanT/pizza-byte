using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Commons.Mappers;

public static class CustomerMapper
{
     public static Customer PostMapToCustomerModel(PostCustomerRequest request)
     {
          var newCustomer = new Customer(
               request.UserName,
               string.Empty, 
               string.Empty, 
               request.Email,
               request.PhoneNumber);

          return newCustomer;
     }
     
     public static CustomerResponse MapToCustomerResponse(Customer customer)
     {
          var response = new CustomerResponse
          {
               Id = customer.Id,
               UserName = customer.UserName,
               Email = customer.Email,
               PhoneNumber = customer.PhoneNumber,
               CreatedAt = customer.CreatedAt,
               LastModifiedDateTime = customer.LastModifiedDateTime
          };
          
          return response;
     }
     
     public static Customer PutMapToCustomerModel(Customer customer, PutCustomerRequest request)
     {
          customer.UserName = request.UserName;
          customer.Email = request.Email;
          // customer.PasswordHash = //TODO: Hash the password
          // customer.PasswordSalt = //TODO: Salt the password
          customer.PhoneNumber = request.PhoneNumber;
          customer.LastModifiedDateTime = DateTime.UtcNow;
          return customer;
     }
}