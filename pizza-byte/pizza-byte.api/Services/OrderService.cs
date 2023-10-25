using LanguageExt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Entities;
using pizza_byte.api.Persistence;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Customer;
using pizza_byte.contracts.pizza_byte.Order;

namespace pizza_byte.api.Services;

public class OrderService : IOrderService
{
    
    private readonly PizzaDbContext _dbContext;

    public OrderService(PizzaDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException(nameof(PizzaDbContext));
    }

    public void PostOrder(Order order)
    {
        // var customer = OrderMapper.PostMapToOrderModel(request);
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }

    public Either<Error, Order> GetOrderById(Guid? id)
    {
        var customer = _dbContext.Orders.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (customer == null) return new OrderNotFound();
        return customer;
    }

    // public Either<Error, IActionResult> PutOrder(Guid id, PutOrderRequest request)
    // {
    //     var customer = _dbContext.Orders.AsNoTracking().FirstOrDefault(x => x.Id == id);
    //     if (customer == null) return new OrderNotFound();
    //     
    //     OrderMapper.PutMapToOrderModel(customer, request);
    //     
    //     return new NoContentResult();
    // }
    
    public Either<Error, IActionResult> DeleteOrder(Guid? id)
    {
        var customer = _dbContext.Orders.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (customer == null) return new OrderNotFound();
        _dbContext.Orders.Remove(customer);
        _dbContext.SaveChanges();
        
        return new NoContentResult();
    }
}