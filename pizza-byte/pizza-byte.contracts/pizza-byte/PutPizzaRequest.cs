namespace pizza_byte.contracts.pizza_byte;

public record PutPizzaRequest(
    string Name,
    List<string> Toppings,
    string Crust,
    string Size,
    decimal Price
);