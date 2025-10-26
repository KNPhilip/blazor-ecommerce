namespace WebUI.Client.Components.Shared;

public sealed partial class SeriesList
{
    protected override void OnInitialized()
    {
        SeriesUIService.OnSeriesChanged += StateHasChanged;
    }

    public void Dispose()
    {
        SeriesUIService.OnSeriesChanged -= StateHasChanged;
    }
}
