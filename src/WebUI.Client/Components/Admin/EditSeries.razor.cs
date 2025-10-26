using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace WebUI.Client.Components.Admin;

public sealed partial class EditSeries
{
    [Parameter]
    public int? Id { get; set; }

    private Domain.Models.Series? series = null;
    private bool Editing;

    protected override async Task OnParametersSetAsync()
    {
        if (Id is not null)
        {
            Domain.Models.Series result = await SeriesUIService
                .GetSeriesByIdAsync(Convert.ToInt32(Id));

            if (result is not null)
            {
                series = result;
                Editing = true;
                return;
            }
        }
        series = new();
    }

    private async Task CreateOrUpdateSeriesAsync()
    {
        if (Editing)
        {
            series = await SeriesUIService.UpdateSeriesAsync(series) ?? new();
            NavigationManager.NavigateTo($"admin/series-editor/{series!.Id}", true);
        }
        else
        {
            Domain.Models.Series result = await SeriesUIService.CreateSeriesAsync(series);
            Snackbar.Add("You created a new series!", Severity.Success);
            NavigationManager.NavigateTo($"admin/series-editor/{result.Id}");
        }
    }

    private async Task DeleteSeriesAsync()
    {
        bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", 
            $"Are you sure you want to delete '{series.Name}'?");

        if (confirmed)
        {
            await SeriesUIService.DeleteSeriesByIdAsync(series.Id);
            NavigationManager.NavigateTo("admin/series");
        }
    }
}
