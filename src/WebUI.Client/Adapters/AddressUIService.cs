using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Models;

namespace WebUI.Client.Adapters;

public sealed class AddressUIService(
    HttpClient http) : IAddressUIService
{
    public async Task<Address> AddOrUpdateAddress(Address address)
    {
        HttpResponseMessage response = await http
            .PostAsJsonAsync("api/v1/addresses", address);
        return response.Content
            .ReadFromJsonAsync<Address>().Result!;
    }

    public async Task<Address> GetAddress()
    {
        Address? response = await http
            .GetFromJsonAsync<Address>("api/v1/addresses");
        return response!;
    }
}
