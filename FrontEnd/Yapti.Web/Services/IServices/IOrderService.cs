using Yapti.Web.Models;

namespace Yapti.Web.Services.IServices
{
    public interface IOrderService
    {
        Task<T> GetAllOrderAsync<T>();
        Task<T> GetOrderByIdAsync<T>(int id);
        Task<T> CreateOrderAsync<T>(OrderDto orderDto);
        Task<T> UpdateOrderAsync<T>(OrderDto orderDto);
        Task<T> DeleteOrderAsync<T>(int id);
    }
}
