using System.ComponentModel.DataAnnotations;

namespace FoodorderBackend.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }              // PK

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } = "User";   // optional (Admin/User)

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
