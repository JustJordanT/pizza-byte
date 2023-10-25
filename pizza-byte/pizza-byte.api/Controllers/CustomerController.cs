using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Entities;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Controllers;
[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    
    private readonly ICustomerService _customerService;
    
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService ?? throw new NullReferenceException(nameof(ICustomerService));
    }

    // POST Customer
    [HttpPost]
    public async Task<IActionResult> PostCustomer(PostCustomerRequest request)
    {

        try
        {
            var response  = await _customerService.PostCustomer(request, new CancellationToken());
            return CreatedAtAction(nameof(GetCustomer), response, new {id = response.Id});
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
    public async Task<IActionResult> GetCustomer(Guid id)
    {
        var customer = await _customerService.GetCustomerById(id, new CancellationToken());

        return customer.Match<IActionResult>(
            Ok,
            NotFound);
    }
    
    // PUT
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutCustomer(Guid id, PutCustomerRequest request)
    {
        await _customerService.PutCustomer(id, request, new CancellationToken());
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _customerService.DeleteCustomer(id, new CancellationToken());
        return customer.Match<IActionResult>(
            Ok,
            NotFound);
    }
}