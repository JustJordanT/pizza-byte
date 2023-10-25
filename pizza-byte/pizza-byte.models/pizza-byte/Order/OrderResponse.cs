namespace pizza_byte.contracts.pizza_byte.Order;

public class OrderResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }
    public DateTime? CompletedDateTime { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Status { get; set; }
    public string? PaymentType { get; set; }
    public Guid CustomerId { get; set; }
}