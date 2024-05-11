using Basket.API.Dtos;
using SharedLib.Dtos;
using System.Text.Json;

namespace Basket.API.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;

    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task<AppResponse<bool>> Delete(string userId)
    {
        var status= await _redisService.GetDb().KeyDeleteAsync(userId);
        return status ? AppResponse<bool>.Success(true, 200) : AppResponse<bool>.Fail("Basket not found", 404);
    }

    public async Task<AppResponse<BasketDto>> GetBasket(string userId)
    {
        var existBasket= await _redisService.GetDb().StringGetAsync(userId);
        if (String.IsNullOrEmpty(existBasket))
            return AppResponse<BasketDto>.Fail("Basket not found",404);

        return AppResponse<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
    }

    public async Task<AppResponse<bool>> SaveOrUpdate(BasketDto request)
    {
        var status =await _redisService.GetDb().StringSetAsync(request.UserId, JsonSerializer.Serialize(request));
        return status ? AppResponse<bool>.Success(true, 200) : AppResponse<bool>.Fail("Basket could not save", 500);
    }
}
