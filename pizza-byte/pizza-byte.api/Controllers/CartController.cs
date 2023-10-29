using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte.Cart;

namespace pizza_byte.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    
    // POST Customer
    [HttpPost]
    public async Task<IActionResult> PostCart(PostCartRequest request)
    {
        try
        {
            var response  = await _cartService.PostCart(request, new CancellationToken());
            return CreatedAtAction(nameof(GetCart), response, new {id = response.Id});
        }
        catch (OperationCanceledException)
        {
            // _logger.LogWarning("Operation was cancelled.");
            return StatusCode(499, "Client closed request."); // 499 is a non-standard status code used to indicate client closed request
        }
        catch (TimeoutException)
        {
            // _logger.LogWarning("Operation timed out.");
            return StatusCode(408, "Request timed out."); // 408 is the standard status code for request timeout
        }
        catch (DbUpdateException ex)
        {
            // _logger.LogError(ex, "Database update failed.");
            return StatusCode(500, "Internal server error."); // Handle other exceptions as appropriate for your use case
        }
    } 
    
    // GET
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCart(Guid id)
    {
        var customer = await _cartService.GetCartById(id, new CancellationToken());

        return customer.Match<IActionResult>(
            Ok,
            NotFound);
    }
}