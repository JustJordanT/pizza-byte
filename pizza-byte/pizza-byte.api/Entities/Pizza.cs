namespace pizza_byte.api.Entities;

public class Pizza
{
    public Guid Id { get; private set; }
    public string? Name { get; internal set; }
    public List<string>? Toppings { get; internal set; }
    public DateTime CreatedDateTime { get; init;  } = DateTime.Now;
    public DateTime? CompletedDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; internal set; } = DateTime.Now;
    public string? Crust { get; internal set; }
    public decimal Price { get; internal set; }
    public string? Size { get; internal set; }
    
    public Pizza()
    {
        
    }
    
    public Pizza(
        Guid id,
        string? name,
        List<string>? toppings,
        DateTime createdDateTime,
        DateTime? completedDateTime,
        DateTime lastModifiedDateTime,
        string? crust,
        decimal price,
        string? size)
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
}

