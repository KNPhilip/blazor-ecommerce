using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Dtos;

namespace WebUI.Client.Adapters;

public sealed class OrderUIService(
    AuthenticationStateProvider authStateProvider,
    HttpClient http) : IOrderUIService
{
    public async Task<OrderDetailsDto> GetOrderDetailsByIdAsync(int orderId)
    {
        OrderDetailsDto? result = await http
            .GetFromJsonAsync<OrderDetailsDto>($"api/v1/orders/{orderId}");
        return result!;
    }

    public async Task<List<OrderOverviewDto>> GetOrdersAsync()
    {
        List<OrderOverviewDto>? result = await http
            .GetFromJsonAsync<List<OrderOverviewDto>>("api/v1/orders");
        return result!;
    }

    public async Task<string> PlaceOrderAsync()
    {
        if (await IsUserAuthenticated())
        {
            HttpResponseMessage result = await http
                .PostAsync("api/v1/payments/checkout", null);
            return await result.Content.ReadAsStringAsync();
        }
        else
        {
            return "account/login";
        }
    }

    private async Task<bool> IsUserAuthenticated()
    {
        return (await authStateProvider
            .GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
    }
}
