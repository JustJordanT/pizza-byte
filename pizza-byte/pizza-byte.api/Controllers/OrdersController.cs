using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Entities;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;
using pizza_byte.contracts.pizza_byte.Order;

namespace pizza_byte.api.Controllers;
[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    
    private readonly IOrderService _orderService;

    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService ?? throw new NullReferenceException(nameof(ICustomerService));
    }

    // POST Customer
    [HttpPost]
    // TODO: trying to get this to work getting a 5xx.
    public async Task<IActionResult> PostCustomer(PostOrderRequest request)
    {

        try
        {
            var response  = await _orderService.PostOrder(request, new CancellationToken());
            return CreatedAtAction(nameof(GetOrder), response, new {id = response.Id});
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
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var customer = await _orderService.GetOrderById(id);

        return customer.Match<IActionResult>(
            Ok,
            NotFound);
    }
    
    // PUT
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutCustomer(Guid id, PutOrderRequest request)
    {
        await _orderService.PutOrder(id, request, new CancellationToken());
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _orderService.DeleteOrder(id, new CancellationToken());
        return customer.Match<IActionResult>(
            Ok,
            NotFound);
    }
}