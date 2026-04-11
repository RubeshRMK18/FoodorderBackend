using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _service;

        public CartController(CartService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetCartAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCartDto dto)
        {
            var item = await _service.AddToCartAsync(dto);
            return Ok(item);
        }
    }
}