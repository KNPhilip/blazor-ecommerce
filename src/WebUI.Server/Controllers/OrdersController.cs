using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using UseCases.Ports.Input;

namespace WebUI.Server.Controllers;

public sealed class OrdersController(
    IOrderService orderService) : ControllerTemplate
{
    private readonly IOrderService orderService = orderService;

    [HttpGet]
    public async Task<ActionResult<List<OrderOverviewDto>>> GetOrders() =>
        HandleResult(await orderService.GetOrdersAsync());

    [HttpGet("{orderId}")]
    public async Task<ActionResult<List<OrderOverviewDto>>> GetOrderDetails(int orderId) =>
        HandleResult(await orderService.GetOrderDetailsAsync(orderId));
}
