using LanguageExt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Commons.Errors;
using pizza_byte.api.Commons.Mappers;
using pizza_byte.api.Entities;
using pizza_byte.api.Persistence;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Cart;
using pizza_byte.contracts.pizza_byte.Customer;

namespace pizza_byte.api.Services;

public class CartService : ICartService
{
    
    private readonly PizzaDbContext _dbContext;

    public CartService(PizzaDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new NullReferenceException(nameof(PizzaDbContext));
    }

    public async Task<CartResponse> PostCart(PostCartRequest request, CancellationToken cancellationToken)
    {
        // var customer = CustomerMapper.PostMapToCustomerModel(request);

        var model = new Cart
        {
            CustomerId = request.CustomerId
        };

        await _dbContext.Carts.AddAsync(model, cancellationToken);
        
        var cart = new CartResponse
        {
            Id = model.Id,
            Pizzas = model.Pizzas.Select(x => x.Id).ToList(),
            Total = model.Total,
            Quantity = model.Quantity,
            CustomerId = model.CustomerId,
            IsActive = model.IsActive,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
        
        
        await _dbContext.SaveChangesAsync(CancellationToken.None);
        // return CustomerMapper.MapToCustomerResponse(cart);
        return cart;
    }

    public async Task<Either<Error, Cart>> GetCartById(Guid? id, CancellationToken cancellationToken)
    {
        var cart = await _dbContext.Carts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        if (cart == null) return new CustomerNotFound();
        return cart;
    }
    //
    // public async Task<Either<Error, ActionResult>> PutCustomer(Guid id, PutCustomerRequest request, CancellationToken cancellationToken)
    // {
    //     var customer = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    //     if (customer == null) return new CustomerNotFound();
    //     
    //     CustomerMapper.PutMapToCustomerModel(customer, request);
    //     
    //     return new NoContentResult();
    // }
    //
    // public async Task<Either<Error, ActionResult>> DeleteCustomer(Guid? id, CancellationToken cancellationToken)
    // {
    //     var customer = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    //     if (customer == null) return new CustomerNotFound();
    //     _dbContext.Customers.Remove(customer);
    //     _dbContext.SaveChanges();
    //     
    //     return new NoContentResult();
    // }
}