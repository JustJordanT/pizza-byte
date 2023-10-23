using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Exceptions;
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
        var pizza = PizzaMapper.PostMapToPizzaModel(request); 
        
        // TODO: Save pizza to database
        _pizzaService.PostPizza(pizza);
        
        var response = PizzaMapper.MapToPizzaResponse(pizza);
        
        return CreatedAtAction(nameof(GetPizza),response, new {id = pizza.Id});
    } 

    [HttpGet("{id:guid}")]
    public IActionResult GetPizza(Guid id)
    {
        // TODO: might need to clean up this error handling
        var pizza = _pizzaService.GetPizzaById(id);
        
        var pizzaResult = pizza.Match(
            Right: pizza =>
            {
                var pizzaModel = pizza;
            },
            Left: error => new PizzaNotFound());
        
        
        
        var response = PizzaMapper.MapToPizzaResponse(pizza);
            
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