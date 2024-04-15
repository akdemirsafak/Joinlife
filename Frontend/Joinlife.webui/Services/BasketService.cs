using Joinlife.webui.Core.Services;
using Joinlife.webui.ViewModels.Baskets;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddBasketItemAsync(BasketItemViewModel basketItem)
    {
        var basket= await GetAsync();
        if(basket is not null)
        {
            basket.BasketItems.Add(basketItem);
        }
        else
        {
            basket = new BasketViewModel();
            //basket.BasketItems=new List<BasketItemViewModel>();
            basket.BasketItems.Add(basketItem);
        }
        await SaveOrUpdateAsync(basket);
    }
    
    public async Task<BasketViewModel> GetAsync()
    {
        var response = await _httpClient.GetAsync("basket");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var basketViewModel = await response.Content.ReadFromJsonAsync<AppResponse<BasketViewModel>>();
        return basketViewModel.Data;
    }
    public async Task<bool> RemoveBasketItemAsync(Guid basketItemId)
    {
        var basket = await GetAsync();

        if (basket is null)
            return false;

        var deleteBasketItem = basket.BasketItems.FirstOrDefault(x => x.TicketId == basketItemId);
        if (deleteBasketItem is null)
            return false;

        var deleteResult = basket.BasketItems.Remove(deleteBasketItem);

        if (!deleteResult)
            return false;

        return await SaveOrUpdateAsync(basket);

    }
    public async Task<bool> DeleteAsync()
    {
        var result= await _httpClient.DeleteAsync("basket");
        return result.IsSuccessStatusCode;
    }
    public async Task<bool> SaveOrUpdateAsync(BasketViewModel basketViewModel)
    {
        var response = await _httpClient.PostAsJsonAsync<BasketViewModel>("basket", basketViewModel);
        return response.IsSuccessStatusCode;
    }
}
