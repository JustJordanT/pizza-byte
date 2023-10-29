using pizza_byte.api.Entities;
using pizza_byte.contracts.pizza_byte;
using pizza_byte.contracts.pizza_byte.Order;

namespace pizza_byte.api.Commons.Mappers;

public static class OrderMapper
{
    public static Order PostRequestToOrderModel(PostOrderRequest request)
    {
        return new Order
        {
            CustomerId = request.CustomerId,
            CartId = request.CartId,
        };
    } 
    
    public static OrderResponse ModelToOrderResponse(Order model)
    {
        return new OrderResponse
        {
            Id = model.Id,
            Status = model.Status,
            PaymentType = model.PaymentType,
            CreatedDateTime = model.CreatedDateTime,
            LastModifiedDateTime = model.LastModifiedDateTime,
            CompletedDateTime = model.CompletedDateTime
        };
    }
    
    public static Order PutMapToOrderModel(Order model, PutOrderRequest request)
    {
        model.Status = request.Status;
        model.PaymentType = request.PaymentType;
        model.LastModifiedDateTime = DateTime.Now;
        return model;
    }
}