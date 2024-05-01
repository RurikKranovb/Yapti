using AutoMapper;
using Yapti.Services.OrderApi.Models;
using Yapti.Services.OrderApi.Models.Dto;

namespace Yapti.Services.OrderApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>();
                config.CreateMap<Order, OrderDto>();
            });

            return mappingConfig;
                
        }
    }
}
