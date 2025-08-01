﻿using Domain.Dtos;
using Microsoft.AspNetCore.Components;

namespace WebUI.Client.Components.Pages;

public sealed partial class OrderDetails
{
    [Parameter]
    public int OrderId { get; set; }

    OrderDetailsDto? order = null;

    protected override async Task OnInitializedAsync()
    {
        order = await OrderUIService.GetOrderDetailsByIdAsync(OrderId);
    }
}
