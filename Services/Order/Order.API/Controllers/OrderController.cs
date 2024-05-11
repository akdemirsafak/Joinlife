using Microsoft.AspNetCore.Mvc;
using Order.Domain.Models;
using Order.Domain.Services;
using SharedLib.BaseController;

namespace Order.API.Controllers
{

    public class OrderController : CustomBaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _orderService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CreateActionResult(await _orderService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            return CreateActionResult(await _orderService.CreateAsync(request));
        }
    }
}