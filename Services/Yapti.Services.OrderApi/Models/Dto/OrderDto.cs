using System.ComponentModel.DataAnnotations;

namespace Yapti.Services.OrderApi.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
