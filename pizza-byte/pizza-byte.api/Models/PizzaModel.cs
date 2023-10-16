using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pizza_byte.api.Models;

public class PizzaModel
{
    public PizzaModel()
    {
        
    }
    public PizzaModel(
        Guid id,
        string name,
        List<string> toppings,
        DateTime createdDateTime,
        DateTime? completedDateTime,
        DateTime lastModifiedDateTime,
        string crust,
        decimal price,
        string size)
    {
        Id = id;
        Name = name;
        Toppings = toppings;
        CreatedDateTime = createdDateTime;
        CompletedDateTime = completedDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Crust = crust;
        Price = price;
        Size = size;
    }
    
    [JsonPropertyName("id")]
    public Guid Id { get; private set; }
    [JsonPropertyName("name")]
    public string Name { get; internal set; }
    [JsonPropertyName("toppings")]
    public List<string> Toppings { get; internal set; }
    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; init;  } = DateTime.Now;
    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get; internal set; } = DateTime.Now;
    [JsonPropertyName("crust")]
    public string Crust { get; internal set; }
    [JsonPropertyName("price")]
    public decimal Price { get; internal set; }
    [JsonPropertyName("size")]
    public string Size { get; internal set; }
}

