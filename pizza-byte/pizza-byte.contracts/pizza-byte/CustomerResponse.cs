using System.Runtime.InteropServices.JavaScript;

namespace pizza_byte.contracts.pizza_byte;

public record CustomerResponse(
    Guid Id,
    string UserName, 
    string Email, 
    string PhoneNumber, 
    DateTime CreatedAt, 
    DateTime LastModifiedDateTime
);