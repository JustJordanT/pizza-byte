using System.Net.Mime;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Exceptions;
using pizza_byte.api.Commons.Mappers;
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
        var pizza = _pizzaService.GetPizzaById(id);

        return pizza.Match<ActionResult>(
           Ok,
           e => NotFound()
        );
    }
       
    [HttpPut("{id:guid}")]
    public IActionResult PutPizza(Guid id, PutPizzaRequest request)
    {
       var pizza = _pizzaService.PutPizza(id, request);
        return pizza.Match<ActionResult>(
            Ok,
            e => NotFound()
        );
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeletePizza(Guid id)
    {
        var pizza = _pizzaService.DeletePizza(id);
        return pizza.Match<ActionResult>(
            _ => NoContent(),
            e => NotFound()
        );
    }
}