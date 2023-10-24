using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte.Customer;

public class PostCustomerRequest
{
    [JsonPropertyName("userName")]
    public string UserName { get; init; } = null!;

    [JsonPropertyName("email")]
    public string Email { get; init; } = null!;

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; init; } = null!;

    [JsonPropertyName("password")]
    public string Password { get; init; } = null!;

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get; init; } = DateTime.Now;
}