using FoodorderBackend.DTOs;
using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Model;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Services
{
    public class CartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItemDto>> GetCartAsync()
        {
            return await _context.CartItems
                .Select(c => new CartItemDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    IsAvailable = c.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<CartItemDto> AddToCartAsync(AddCartDto dto)
        {
            var item = new CartItem
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                IsAvailable = dto.IsAvailable
            };

            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();

            return new CartItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                IsAvailable = item.IsAvailable
            };
        }
    }
}
