using Mapster;
using Order.Domain.Models;
using Order.Domain.Repositories;
using Order.Domain.Services;
using SharedLib.Dtos;

namespace Order.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<AppResponse<CreatedOrderResponse>> CreateAsync(CreateOrderRequest request)
        {
            //var order=request.Adapt<Order.Domain.Entity.Order>();
            
            
            var order = new Domain.Entity.Order
            {
                BuyerId = request.BuyerId,
                OrderItems=new List<Domain.Entity.OrderItem>()
            };
            request.OrderItems.ForEach(orderItem => order.OrderItems.Add(
                new Domain.Entity.OrderItem { 
                    Amount=orderItem.Amount,
                    Price=orderItem.Price,
                    TicketId=orderItem.TicketId,
                    TicketName=orderItem.TicketName
                }));
            order.TotalPrice= order.OrderItems.Sum(item => item.Price * item.Amount);
            // !  order.BuyerId = request.BuyerId; // TODO CurrentUserId
            await _orderRepository.CreateAsync(order);

            return AppResponse<CreatedOrderResponse>.Success(order.Adapt<CreatedOrderResponse>(),201);
        }

        public async Task<AppResponse<List<GetOrderResponse>>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return AppResponse<List<GetOrderResponse>>.Success(orders.Adapt<List<GetOrderResponse>>(),200);
        }

        public async Task<AppResponse<GetOrderResponse>> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return AppResponse<GetOrderResponse>.Success(order.Adapt<GetOrderResponse>(),200);
        }
    }
}