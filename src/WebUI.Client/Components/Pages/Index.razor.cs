using Microsoft.AspNetCore.Components;

namespace WebUI.Client.Components.Pages;

public sealed partial class Index
{
    [Parameter]
    public string? CategoryUrl { get; set; }

    [Parameter]
    public string? SearchTerm { get; set; } = null;

    [Parameter]
    public int Page { get; set; } = 1;

    protected override async Task OnParametersSetAsync()
    {
        if (SearchTerm is not null)
        {
            await ProductUIService.SearchProductsAsync(SearchTerm, Page);
        }
        else
        {
            if (CategoryUrl is null)
                await SeriesUIService.GetSeriesAsync();

            await ProductUIService.GetProductsAsync(CategoryUrl);
        }
    }
}
