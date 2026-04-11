using FoodorderBackend.Data;
using FoodorderBackend.DTO;
using FoodorderBackend.Model;

namespace FoodorderBackend.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public string PlaceOrder(PlaceorderDto dto)
        {
            // list cart items
            var cartItems = _context.CartItem.Where(c => c.UserId == dto.UserId).ToList();

            if (!cartItems.Any())
            {
                return "No items in cart";
            }

            var totalPrice = cartItems.Sum(c => c.Price * c.Quantity);

            var order = new Order
            {
                UserId = dto.UserId,
                TotalAmount = totalPrice,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending"
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.RemoveRange(cartItems);
            _context.SaveChanges();
            return "Order placed successfully";
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }
    }
}
