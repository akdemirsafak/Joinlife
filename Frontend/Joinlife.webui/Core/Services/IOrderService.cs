using Joinlife.webui.ViewModels.Orders;

namespace Joinlife.webui.Core.Services;

public interface IOrderService
{
    Task<List<OrderViewModel>> GetAllAsync();
    Task<OrderViewModel> GetByIdAsync(Guid id);
    Task<OrderViewModel> CreateAsync(CheckoutInfoInput input);
    Task CancelOrder(Guid id);
}
