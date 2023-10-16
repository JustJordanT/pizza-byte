namespace pizza_byte.contracts.pizza_byte;

public record PostPizzaRequest(
    string Name,
    List<string> Toppings,
    string Crust,
    string Size
);