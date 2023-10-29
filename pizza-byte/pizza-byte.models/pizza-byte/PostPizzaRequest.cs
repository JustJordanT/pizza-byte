using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte;

public class PostPizzaRequest
{
    [JsonPropertyName("name")] public string? Name { get; init; } = null!;
    [JsonPropertyName("toppings")] public List<string> Toppings { get; init; } = null!;
    [JsonPropertyName("crust")] public string? Crust { get; init; } = null!;
    [JsonPropertyName("size")] public string Size { get; init; } = null!;
    [JsonPropertyName("cart_id")] public Guid CartId { get; init; }
}