namespace WebUI.Client.Components.Layout;

public sealed partial class FavoritesCounter
{
    protected override void OnInitialized()
    {
        FavoriteUIService.OnFavoritesChanged += StateHasChanged;
        FavoriteUIService.GetFavoritesAsync();
    }

    public void Dispose()
    {
        FavoriteUIService.OnFavoritesChanged -= StateHasChanged;
    }
}
