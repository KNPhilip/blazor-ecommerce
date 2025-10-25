using System.Net.Http.Json;
using WebUI.Client.Ports;
using Domain.Models;

namespace WebUI.Client.Adapters;

public sealed class PublisherUIService(HttpClient http) : IPublisherUIService
{
    public async Task<DbUser> GetPublisherByIdAsync(string id)
    {
        DbUser? response = await http.GetFromJsonAsync<DbUser>($"api/v1/publisher/{id}");
        return response!;
    }

    public async Task<DbUser> CreatePublisherAsync(DbUser publisher)
    {
        HttpResponseMessage response = await http
            .PostAsJsonAsync("api/v1/publisher", publisher);

        return response.Content.ReadFromJsonAsync<DbUser>().Result!;
    }

    public async Task<DbUser> UpdatePublisherAsync(DbUser publisher)
    {
        HttpResponseMessage response = await http
            .PostAsJsonAsync("api/v1/publisher", publisher);

        return response.Content.ReadFromJsonAsync<DbUser>().Result!;
    }

    public async Task DeletePublisherByIdAsync(string id)
    {
        await http.DeleteAsync($"api/v1/publisher/{id}");
    }
}
