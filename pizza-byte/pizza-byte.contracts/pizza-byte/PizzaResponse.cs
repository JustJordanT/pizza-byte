namespace pizza_byte.contracts.pizza_byte;

public record PizzaResponse(
    Guid Id,
    string Name,
    DateTime CreatedDateTime,
    DateTime? CompletedDateTime,
    DateTime LastModifiedDateTime,
    List<string> Toppings,
    string Crust,
    string Size,
    decimal Price
);