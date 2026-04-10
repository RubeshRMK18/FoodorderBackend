namespace FoodOrderingSystem.DTOs
{
    public class AddCartDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }

    }
}