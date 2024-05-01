using Yapti.Services.OrderApi.Models.Dto;

namespace Yapti.Services.OrderApi.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderId);
        Task<OrderDto> CreateUpdateOrder(OrderDto orderDto);
        Task<bool> DeleteOrder(int orderId);
    }
}
