using System.Runtime.InteropServices.JavaScript;

namespace pizza_byte.contracts.pizza_byte;

public record PutCustomerRequest(
     string UserName, 
     string Email ,
     string PhoneNumber, 
     string Password
     // DateTime CreatedAt,
     // DateTime LastModifiedDateTime 
);