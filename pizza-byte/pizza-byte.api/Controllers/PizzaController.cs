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
public class PizzaController : ControllerBase
{
   
    
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpPost]
    public IActionResult PostPizza(PostPizzaRequest request)
    {
        var response = _pizzaService.PostPizza(request);
        return CreatedAtAction(nameof(GetPizza),response, new {id = response.Id});
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