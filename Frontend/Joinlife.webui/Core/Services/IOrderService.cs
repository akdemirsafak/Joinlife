﻿using Joinlife.webui.ViewModels.Orders;

namespace Joinlife.webui.Core.Services;

public interface IOrderService
{
    Task<List<OrderViewModel>> GetCheckoutHistory();
    Task<OrderViewModel> GetByIdAsync(Guid id);
    Task<OrderViewModel> CreateAsync(CheckoutInfoInput input);
}
