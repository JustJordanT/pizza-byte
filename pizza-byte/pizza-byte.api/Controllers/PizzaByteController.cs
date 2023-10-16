using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Models;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

namespace pizza_byte.api.Controllers;


[ApiController]
[Route("api/pizza")]
public class PizzaByteController : ControllerBase
{
   
    
    private readonly IPizzaService _pizzaService;

    public PizzaByteController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpPost]
    public IActionResult PostPizza(PostPizzaRequest request)
    {
        var pizza = PizzaMapper.PostMapToPizzaByte(request); 
        
        // TODO: Save pizza to database
        _pizzaService.PostPizza(pizza);
        
        var response = PizzaMapper.MapToPizzaResponse(pizza);
        
        return CreatedAtAction(nameof(GetPizza),response, new {id = pizza.Id});
    } 

    [HttpGet("{id:guid}")]
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
       
    [HttpPut("{id:guid}")]
    public IActionResult PutPizza(Guid id, PutPizzaRequest request)
    {
        _pizzaService.PutPizza(id, request);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeletePizza(Guid id)
    {
        _pizzaService.DeletePizza(id);
        return NoContent();
    }
}