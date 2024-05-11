using Order.Domain.Models;
using SharedLib.Dtos;

namespace Order.Domain.Services
{
    public interface IOrderService
    {
        Task<AppResponse<List<GetOrderResponse>>> GetAllAsync();
        Task<AppResponse<GetOrderResponse>> GetByIdAsync(Guid id);

        Task<AppResponse<CreatedOrderResponse>> CreateAsync(CreateOrderRequest request);
    }
}