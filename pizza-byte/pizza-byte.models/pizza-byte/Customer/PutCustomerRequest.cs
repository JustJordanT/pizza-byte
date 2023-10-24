using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte.Customer;

public class PutCustomerRequest
{
     [JsonPropertyName("userName")]
     public string UserName { get; init; }
     [JsonPropertyName("email")]
     public string Email { get; init; }
     [JsonPropertyName("phoneNumber")]
     public string PhoneNumber { get; init; }
     [JsonPropertyName("password")]
     public string Password { get; init; }
}