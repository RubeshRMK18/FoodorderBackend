using System.ComponentModel.DataAnnotations;

namespace FoodorderBackend.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
