using System.ComponentModel.DataAnnotations;

namespace Yapti.Services.OrderApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1,1000)]
        public double Price { get; set; }

        public string Description { get; set; }
        public string CategoryName { get; set;}

        public string ImageUrl { get; set; }

        public string Message { get; set; } = "";

        public DateTime DeadLine { get; set; } = DateTime.Now;

    }
}
