using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte;

public class PizzaResponse
{
    [JsonPropertyName("Id")]  public Guid Id { get; set; }
    [JsonPropertyName("Name")] public string Name { get; set; }
    [JsonPropertyName("CreatedDateTime")] public DateTime CreatedDateTime { get; set; }
    [JsonPropertyName("CompletedDateTime")] public DateTime? CompletedDateTime { get; set; }
    [JsonPropertyName("LastModifiedDateTime")] public DateTime LastModifiedDateTime { get; set; }
    [JsonPropertyName("Toppings")] public List<string>? Toppings { get; set; }
    [JsonPropertyName("Crust")] public string? Crust { get; set; }
    [JsonPropertyName("Size")] public string? Size { get; set; }
    [JsonPropertyName("Price")] public decimal Price { get; set; }
}