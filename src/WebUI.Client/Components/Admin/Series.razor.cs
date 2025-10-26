using Microsoft.AspNetCore.Components;

namespace WebUI.Client.Components.Admin;

public sealed partial class Series
{
    protected override async Task OnInitializedAsync()
    {
        await SeriesUIService.GetSeriesAsync();
    }

    private void EditSeries(int seriesId)
    {
        NavigationManager.NavigateTo($"admin/series-editor/{seriesId}");
    }

    private void CreateSeries()
    {
        NavigationManager.NavigateTo($"admin/series-editor");
    }
}
