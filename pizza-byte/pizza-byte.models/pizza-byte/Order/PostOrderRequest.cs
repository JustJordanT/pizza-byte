using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte.Order;

public class PostOrderRequest
{
    [JsonPropertyName("CustomerId")]
    public Guid CustomerId { get; set; }
    [JsonPropertyName("TotalPrice")]
    public decimal TotalPrice { get; set; }
    [JsonPropertyName("Status")]
    public string? Status { get; set; }
    [JsonPropertyName("PaymentType")]
    public string? PaymentType { get; set; }
}