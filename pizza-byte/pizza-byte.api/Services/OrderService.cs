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

    public async Task<OrderResponse> PostOrder(PostOrderRequest request,
        CancellationToken cancellationToken)
    {
        var model = OrderMapper.PostRequestToOrderModel(request);
        // if (model.CustomerId != CustomerId) return new CustomerNotFound();
        // TODO: not sure how the error validation should be handled here.
        await _dbContext.Orders.AddAsync(model, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return OrderMapper.ModelToOrderResponse(model);
    }

    public async Task<Either<Error, Order>> GetOrderById(Guid? id)
    {
        var order = await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (order == null) return new OrderNotFound();
        return order;
    }

    public async Task<Either<Error, IActionResult>> PutOrder(Guid id, PutOrderRequest request,
        CancellationToken cancellationToken)
    {
        var customer = await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,
            cancellationToken: cancellationToken);
        if (customer == null) return new OrderNotFound();
        
        OrderMapper.PutMapToOrderModel(customer, request);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return new NoContentResult();
    }
    
    public async Task<Either<Error, IActionResult>> DeleteOrder(Guid? id,
        CancellationToken cancellationToken)
    {
        var customer = await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id,
            cancellationToken: cancellationToken);
        if (customer == null) return new OrderNotFound();
        _dbContext.Orders.Remove(customer);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return new NoContentResult();
    }
}