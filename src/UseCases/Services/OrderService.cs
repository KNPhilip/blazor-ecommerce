using UseCases.Ports.Input;
using UseCases.Ports.Output;
using Domain.Models;
using Domain.Dtos;

namespace UseCases.Services;

public sealed class OrderService(IAuthService authService,
    ICartService cartService, IOrderRepository repository) : IOrderService
{
    private readonly IAuthService authService = authService;
    private readonly ICartService cartService = cartService;
    private readonly IOrderRepository repository = repository;

    public async Task<Result<List<OrderOverviewDto>>> GetOrdersAsync()
    {
        string userId = await authService.GetUserIdAsync();
        List<Order> orders = await repository.GetOrdersByUserIdAsync(userId);

        List<OrderOverviewDto> orderResponse = [];

        orders.ForEach(o => orderResponse.Add(new OrderOverviewDto
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            TotalPrice = o.TotalPrice,
            Product = o.OrderItems.Count > 1 ?
                $"{o.OrderItems.First().Product!.Title} and " +
                $"{o.OrderItems.Count - 1} more..." :
                o.OrderItems.First().Product!.Title,
            ProductImageUrl = o.OrderItems.First().Product!.ImageUrl,
            Images = o.OrderItems.First().Product!.Images
        }));
        return orderResponse;
    }

    public async Task<Result<OrderDetailsDto>> GetOrderDetailsAsync(int orderId)
    {
        string userId = await authService.GetUserIdAsync();
        Order order = await repository.GetOrderByIdAsync(userId, orderId);

        if (order is null)
        {
            return Result.Fail<OrderDetailsDto>("Order not found.");
        }

        OrderDetailsDto orderDetailsResponse = new()
        {
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Products = []
        };
        order.OrderItems.ForEach(item =>
        orderDetailsResponse.Products.Add(new OrderDetailsProductDto
        {
            ProductId = item.ProductId,
            ImageUrl = item.Product!.ImageUrl,
            Images = item.Product.Images,
            ProductType = item.ProductType!.Name,
            Quantity = item.Quantity,
            Title = item.Product.Title,
            TotalPrice = item.TotalPrice
        }));
        return orderDetailsResponse;
    }

    public async Task<Result<bool>> PlaceOrderForEmailAsync(string email)
    {
        List<CartProductResponseDto>? products = await cartService.GetCartItemsAsync(email);
        decimal totalPrice = 0;
        products?.ForEach(product => totalPrice += product.Price * product.Quantity);

        Order order = new()
        {
            UserId = email,
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice
        };

        products?.ForEach(product => order.OrderItems.Add(new OrderItem
        {
            Order = order,
            ProductId = product.ProductId,
            ProductTypeId = product.ProductTypeId,
            Quantity = product.Quantity,
            TotalPrice = product.Price * product.Quantity
        }));

        await repository.CreateOrderForUserAsync(email, order);

        return true;
    }
}
