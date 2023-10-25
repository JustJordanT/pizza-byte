// using Microsoft.AspNetCore.Mvc;
// using pizza_byte.api.Entities;
// using pizza_byte.api.Services;
// using pizza_byte.contracts.pizza_byte;
// using pizza_byte.contracts.pizza_byte.Customer;
//
// namespace pizza_byte.api.Controllers;
// [ApiController]
// [Route("api/customer")]
// public class OrderController : ControllerBase
// {
//     
//     private readonly IOrderService _orderService;
//
//     
//     public OrderController(IOrderService orderService)
//     {
//         _orderService = orderService ?? throw new NullReferenceException(nameof(ICustomerService));
//     }
//
//     // POST Customer
//     [HttpPost]
//     public IActionResult PostOrder(PostCustomerRequest request)
//     {
//          var order  = _orderService.PostOrder(request);
//          var response = Commons.Mappers.CustomerMapper.MapToOrderResponse(order);
//         return CreatedAtAction(nameof(GetCustomer), response, new {id = order.Id});
//     }
//     
//     // GET
//     [HttpGet("{id:guid}")]
//     public IActionResult GetCustomer(Guid id)
//     {
//         var customer = _customerService.GetCustomerById(id);
//
//         return customer.Match<IActionResult>(
//             Ok,
//             NotFound);
//     }
//     
//     // PUT
//     [HttpPut("{id:guid}")]
//     public IActionResult PutCustomer(Guid id, PutCustomerRequest request)
//     {
//         _orderService.PutCustomer(id, request);
//         return NoContent();
//     }
//     //
//     // // DELETE
//     // public IActionResult DeleteCustomer()
//     // {
//     //     throw new NotImplementedException();
//     // }
// }