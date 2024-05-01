using System.ComponentModel.DataAnnotations;

namespace Yapti.Web.Models
{
    public class OrderDto
    {
        public OrderDto()
        {
            Message = "";
        }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

        //[Range(1,255)]
        public string Message { get; set; } = "";

        public DateTime DeadLine { get; set; } = DateTime.Now;
    }
}
