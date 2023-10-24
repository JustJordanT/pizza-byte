using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte;

public class PutPizzaRequest
{
    [JsonPropertyName("id")]
    public string? Name { get; init; }
    [JsonPropertyName("toppings")]
    public List<string>? Toppings { get; init; }
    [JsonPropertyName("crust")]
    public string? Crust { get; init; }
    [JsonPropertyName("price")]
    public string? Size { get; init; }
}