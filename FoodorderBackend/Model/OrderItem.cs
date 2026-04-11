using System.ComponentModel.DataAnnotations;

namespace FoodorderBackend.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; } 
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }   
    }
}
