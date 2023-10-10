using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Models;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Controllers;


[ApiController]
public class PizzaByteController : ControllerBase
{
   
    
    private readonly IPizzaService _pizzaService;

    public PizzaByteController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpPost("api/pizza")]
    public IActionResult PostPizza(PostPizzaRequest request)
    {
        var pizza = new PizzaByte(
            Guid.NewGuid(),
            request.Name,
            request.Toppings,
            DateTime.UtcNow,
            null,
            DateTime.UtcNow,
            request.Crust,
            request.Price,
            request.Size); 
        
        // TODO: Save pizza to database
        _pizzaService.PostPizza(pizza);
        
        var response = new PizzaResponse(
            pizza.Id,
            pizza.Name,
            pizza.CreatedDateTime,
            pizza.CompletedDateTime,
            pizza.LastModifiedDateTime,
            pizza.Toppings,
            pizza.Crust,
            pizza.Size,
            pizza.Price);
        
        return CreatedAtAction(nameof(GetPizza),response, new {id = pizza.Id});
    } 

    [HttpGet("api/pizza/{id:guid}")]
    public IActionResult GetPizza(Guid id)
    {
        var pizza = _pizzaService.GetPizzaById(id);
        
        var response = new PizzaResponse(
            pizza.Id,
            pizza.Name,
            pizza.CreatedDateTime,
            pizza.CompletedDateTime,
            pizza.LastModifiedDateTime,
            pizza.Toppings,
            pizza.Crust,
            pizza.Size,
            pizza.Price);
        
        return Ok(response);
    }
       
    [HttpPut("api/pizza/{id:guid}")]
    public IActionResult PutPizza(Guid id, PutPizzaRequest request)
    {
        _pizzaService.PutPizza(id, request);
        return Ok();
    }
    
    [HttpDelete("api/pizza/{id:guid}")]
    public IActionResult DeletePizza(Guid id)
    {
        _pizzaService.DeletePizza(id);
        return NoContent();
    }
}