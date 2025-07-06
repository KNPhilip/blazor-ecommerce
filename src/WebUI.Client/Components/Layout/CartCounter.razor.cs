namespace WebUI.Client.Components.Layout;

public sealed partial class CartCounter
{
    private int cartItemsCount;

    protected override void OnInitialized()
    {
        CartUIService.OnChange += HandleCartChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        cartItemsCount = await CartUIService.GetCartItemsCountAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await CartUIService.SetCartItemsCountAsync(cartItemsCount);
        cartItemsCount = await GetCartItemsCountAsync();
    }

    public void Dispose()
    {
        CartUIService.OnChange -= HandleCartChanged;
    }

    private async void HandleCartChanged()
    {
        cartItemsCount = await GetCartItemsCountAsync();
        StateHasChanged();
    }

    private async Task<int> GetCartItemsCountAsync()
    {
        return await LocalStorage.GetItemAsync<int>("cartItemsCount");
    }
}
