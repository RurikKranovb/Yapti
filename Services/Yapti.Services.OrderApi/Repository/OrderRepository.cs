using System.Collections;
using AutoMapper;
using Yapti.Services.OrderApi.DbContexts;
using Yapti.Services.OrderApi.Models;
using Yapti.Services.OrderApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Yapti.Services.OrderApi.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public OrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            List<Order> orderList = await _db.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(orderList);

        }

        public async Task<OrderDto> GetOrderById(int orderId)
        {
            Order? orderList = await _db.Orders.Where(x=>x.OrderId == orderId).FirstOrDefaultAsync();
            return _mapper.Map<OrderDto>(orderList);
        }

        public async Task<OrderDto> CreateUpdateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);

            if (order.OrderId > 0)
            {
                _db.Orders.Update(order);
            }
            else
            {
                _db.Orders.Add(order);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            try
            {
                Order? order = await _db.Orders.FirstOrDefaultAsync(u => u.OrderId == orderId);

                if (order == null)
                {
                    return false;
                }

                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
