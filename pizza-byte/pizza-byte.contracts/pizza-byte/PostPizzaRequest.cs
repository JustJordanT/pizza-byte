namespace pizza_byte.contracts.pizza_byte;

public record PostPizzaRequest(
    string Name,
    DateTime CreatedDate,
    DateTime CompletedDate,
    List<string> Toppings,
    string Crust,
    string Size,
    double Price
);