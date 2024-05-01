using Yapti.Web.Models;
using Yapti.Web.Services.IServices;

namespace Yapti.Web.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public OrderService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> GetAllOrderAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "api/orders",
                AccessToken = ""
            });
        }

        public async Task<T> GetOrderByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "api/orders/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> CreateOrderAsync<T>(OrderDto orderDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderDto,
                Url = SD.OrderAPIBase + "api/orders",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateOrderAsync<T>(OrderDto orderDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = orderDto,
                Url = SD.OrderAPIBase + "api/orders",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteOrderAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.OrderAPIBase + "api/orders/" + id,
                AccessToken = ""
            });
        }
    }
}
