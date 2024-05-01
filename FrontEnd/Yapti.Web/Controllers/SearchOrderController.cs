using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yapti.Web.Models;
using Yapti.Web.Services.IServices;

namespace Yapti.Web.Controllers
{
    public class SearchOrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        public SearchOrderController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        // GET: SearchOrderController
        public async Task<IActionResult> Index()
        {
            List<OrderDto> list = new();

            var response = await _orderService.GetAllOrderAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        // GET: SearchOrderController/Details/5
        public async Task<IActionResult> Details(int orderId)
        {
            OrderDto model = new();

            var response = await _orderService.GetOrderByIdAsync<ResponseDto>(orderId);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<OrderDto>(Convert.ToString(response.Result));
            }

            return View(model);
        }

    }
}
