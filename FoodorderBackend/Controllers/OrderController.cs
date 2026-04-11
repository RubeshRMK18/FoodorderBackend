using FoodorderBackend.DTO;
using FoodorderBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodorderBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]

        public IActionResult PlaceOrder(PlaceorderDto dto)
        {
            var result = _orderService.PlaceOrder(dto);
            if (result.Contains("No items in cart"))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{UserId}")]

        public IActionResult GetOrder(int UserId)
        {
            var result = _orderService.GetOrdersByUserId(UserId);
            return Ok(result);
        }
    }
}
