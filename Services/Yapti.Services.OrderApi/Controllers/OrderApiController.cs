using Yapti.Services.OrderApi.Models.Dto;
using Yapti.Services.OrderApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Yapti.Services.OrderApi.Controllers
{
    [Route("api/orders")]
    //[ApiController]
    public class OrderApiController : ControllerBase
    {
        protected ResponseDto _response;
        private IOrderRepository _orderRepository;

        public OrderApiController(IOrderRepository orderRepository)
        {
            _orderRepository= orderRepository;

            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<OrderDto> orderDtos = await _orderRepository.GetOrders();

                _response.Result = orderDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                OrderDto orderDtos = await _orderRepository.GetOrderById(id);

                _response.Result = orderDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] OrderDto orderDto)
        {
            try
            {
                OrderDto model = await _orderRepository.CreateUpdateOrder(orderDto);

                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] OrderDto orderDto)
        {
            try
            {
                OrderDto model = await _orderRepository.CreateUpdateOrder(orderDto);

                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess= await _orderRepository.DeleteOrder(id);

                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

    }
}
