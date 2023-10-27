using System.Text.Json.Serialization;

namespace pizza_byte.contracts.pizza_byte.Order;

public class OrderResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; set; }
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get; set; }
    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }
    [JsonPropertyName("totalPrice")]
    public decimal TotalPrice { get; set; }
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    [JsonPropertyName("paymentType")]
    public string? PaymentType { get; set; }
    [JsonPropertyName("customerId")]
    public Guid CustomerId { get; set; }
}