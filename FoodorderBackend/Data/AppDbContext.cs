<<<<<<< HEAD
=======
﻿using FoodorderBackend.Model;
>>>>>>> 6f36fb6 (resolved merge conflicts)
using FoodOrderingSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Model.User> Users { get; set; }
<<<<<<< HEAD
        public DbSet<Food> Foods { get; set; } 
=======

        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
>>>>>>> 6f36fb6 (resolved merge conflicts)
    }
}
