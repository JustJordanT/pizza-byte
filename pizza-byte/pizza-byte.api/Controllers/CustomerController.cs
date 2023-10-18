using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Services;
using pizza_byte.contracts.pizza_byte;

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
    public IActionResult PostCustomer(PostCustomerRequest request)
    {
         var customer  = _customerService.PostCustomer(request);
         var response = Commons.Mappers.CustomerMapper.MapToCustomerResponse(customer);
        return CreatedAtAction(nameof(GetCustomer), response, new {id = customer.Id});
    }
    
    // GET
    [HttpGet("{id:guid}")]
    public IActionResult GetCustomer(Guid id)
    {
        var customer = _customerService.GetCustomerById(id);
        var response = Commons.Mappers.CustomerMapper.MapToCustomerResponse(customer);
        return Ok(response);
    }
    
    // PUT
    [HttpPut("{id:guid}")]
    public IActionResult PutCustomer(Guid id, PutCustomerRequest request)
    {
        _customerService.PutCustomer(id, request);
        return NoContent();
    }
    //
    // // DELETE
    // public IActionResult DeleteCustomer()
    // {
    //     throw new NotImplementedException();
    // }
}