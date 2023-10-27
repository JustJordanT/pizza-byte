using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte.Order;

public class PutOrderRequest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("totalPrice")]
    public decimal TotalPrice { get; set; }
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    [JsonPropertyName("paymentType")]
    public string? PaymentType { get; set; }
}