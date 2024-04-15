using Basket.API.Dtos;
using SharedLib.Dtos;

namespace Basket.API.Services;

public interface IBasketService
{
    Task<AppResponse<BasketDto>> GetBasket(string userId);
    Task<AppResponse<bool>> SaveOrUpdate(BasketDto request);
    Task<AppResponse<bool>> Delete(string userId);
}