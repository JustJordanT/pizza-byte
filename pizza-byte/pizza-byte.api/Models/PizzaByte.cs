namespace pizza_byte.api.Models;

public class PizzaByte
{
    public PizzaByte(
        Guid id,
        string name,
        List<string> toppings,
        DateTime createdDateTime,
        DateTime? completedDateTime,
        DateTime lastModifiedDateTime,
        string crust,
        double price,
        string size)
    {
        Id = id;
        Name = name;
        Toppings = toppings;
        CreatedDateTime = createdDateTime;
        CompletedDateTime = completedDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Crust = crust;
        Price = price;
        Size = size;
    }

    public Guid Id { get; }
    public string Name { get; set; }
    public List<string> Toppings { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime? CompletedDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }
    public string Crust { get; set; }
    public double Price { get; set; }
    public string Size { get; set; }
}

