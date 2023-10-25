namespace pizza_byte.contracts.pizza_byte.Order;

public class PutOrderRequest
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Status { get; set; }
    public string? PaymentType { get; set; }
}