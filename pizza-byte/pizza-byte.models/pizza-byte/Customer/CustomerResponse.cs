using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte;

public class CustomerResponse
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }
    [JsonPropertyName("UserName")]
    public string UserName { get; set; }
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("Password")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("LastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get; set; }
};