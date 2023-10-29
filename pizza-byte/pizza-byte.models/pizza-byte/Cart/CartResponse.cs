namespace pizza_byte.contracts.pizza_byte.Cart;

public class CartResponse
{
    public Guid Id { get; set; }
    public List<Guid> Pizzas { get; set; }
    public decimal Total { get; set; }
    public int Quantity { get; set; }
    public Guid CustomerId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 
}