using Yapti.Web.Models;
using Yapti.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Yapti.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderIndex()
        {
            List<OrderDto> list = new();

            var response = await _orderService.GetAllOrderAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderDto>>(
                    Convert.ToString(response.Result) ?? string.Empty);
            }

            return View(list);
        }

        public async Task<IActionResult> OrderCreate()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderCreate(OrderDto model)
        {
            if (ModelState.IsValid)
            {

                var response = await _orderService.CreateOrderAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> OrderEdit(int orderId)
        {

            var response = await _orderService.GetOrderByIdAsync<ResponseDto>(orderId);
            if (response != null && response.IsSuccess)
            {
                OrderDto model = JsonConvert.DeserializeObject<OrderDto>(
                    Convert.ToString(response.Result) ?? string.Empty);

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderEdit(OrderDto model)
        {
            if (ModelState.IsValid)
            {

                var response = await _orderService.UpdateOrderAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> OrderDelete(int orderId)
        {

            var response = await _orderService.GetOrderByIdAsync<ResponseDto>(orderId);
            if (response != null && response.IsSuccess)
            {
                OrderDto model = JsonConvert.DeserializeObject<OrderDto>(
                    Convert.ToString(response.Result) ?? string.Empty);

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderDelete(OrderDto model)
        {
            if (ModelState.IsValid)
            {

                var response = await _orderService.DeleteOrderAsync<ResponseDto>(model.OrderId);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderIndex));
                }
            }

            return View(model);
        }
    }
}
