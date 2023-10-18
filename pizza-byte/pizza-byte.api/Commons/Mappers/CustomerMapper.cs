using pizza_byte.api.Models;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Commons.Mappers;

public static class CustomerMapper
{
     public static CustomerModel PostMapToCustomerModel(PostCustomerRequest request)
     {
          var newCustomer = new CustomerModel(
               request.UserName,
               string.Empty, 
               string.Empty, 
               request.Email,
               request.PhoneNumber);

          return newCustomer;
     }
     
     public static CustomerResponse MapToCustomerResponse(CustomerModel customer)
     {
          var response = new CustomerResponse(
               customer.Id,
               customer.Username,
               customer.Email,
               customer.PhoneNumber,
               customer.CreatedAt,
               customer.LastModifiedDateTime);
          return response;
     }
     
     public static CustomerModel PutMapToCustomerModel(CustomerModel customer, PutCustomerRequest request)
     {
          customer.Username = request.UserName;
          customer.Email = request.Email;
          // customer.PasswordHash = //TODO: Hash the password
          // customer.PasswordSalt = //TODO: Salt the password
          customer.PhoneNumber = request.PhoneNumber;
          customer.LastModifiedDateTime = DateTime.UtcNow;
          return customer;
     }
}