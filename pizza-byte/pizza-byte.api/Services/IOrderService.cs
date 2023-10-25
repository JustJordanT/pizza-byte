using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Order;

namespace pizza_byte.api.Services;

public interface IOrderService
{
    public void PostOrder(Order pizza);
    Either<Error, Order> GetOrderById(Guid? id);
    Either<Error, IActionResult> DeleteOrder(Guid? id);
    // public Either<Error, IActionResult> PutOrder(Guid id, PutOrderRequest request);
}