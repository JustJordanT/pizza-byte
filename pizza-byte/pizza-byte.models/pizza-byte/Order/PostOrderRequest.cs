using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte.Order;

public class PostOrderRequest
{
    [JsonPropertyName("CustomerId")] public Guid CustomerId { get; set; }
    [JsonPropertyName("CartId")] public Guid CartId { get; set; }
}