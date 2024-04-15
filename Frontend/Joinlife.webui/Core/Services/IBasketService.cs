using Joinlife.webui.ViewModels.Baskets;

namespace Joinlife.webui.Core.Services;

public interface IBasketService
{
    Task<bool> DeleteAsync();
    Task<bool> SaveOrUpdateAsync(BasketViewModel basketViewModel);
    Task<bool> RemoveBasketItemAsync(Guid basketItemId);
    Task<BasketViewModel> GetAsync();
    Task AddBasketItemAsync(BasketItemViewModel basketItem);
}
