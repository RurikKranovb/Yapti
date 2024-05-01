using Yapti.Services.OrderApi.Models;
using Microsoft.EntityFrameworkCore;


namespace Yapti.Services.OrderApi.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                Name = "Почистить зубы псу",
                Price = 3000,
                Description = "Так как я больше не могу этим заниматься, псу 8 лет, Лабрадор",
                ImageUrl = "",
                CategoryName = "Какая-то категория",
                Message = "",
                DeadLine = DateTime.Now,
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                Name = "Помыть полки",
                Price = 1200,
                Description = "На кухне и ванной",
                ImageUrl = "",
                CategoryName = "Какая-то категория",
                Message = "",
                DeadLine = DateTime.Now,
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 3,
                Name = "Сделать макет сайта",
                Price = 60000,
                Description = "а то меня попросили, а я не умею",
                ImageUrl = "",
                CategoryName = "Какая-то категория",
                Message = "",
                DeadLine = DateTime.Now,
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 4,
                Name = "Покормить кота по адресу",
                Price = 15,
                Description = "Ключ у соседа",
                ImageUrl = "",
                CategoryName = "Какая-то категория",
                Message = "",
                DeadLine = DateTime.Now,
            });
        }
    }
}
