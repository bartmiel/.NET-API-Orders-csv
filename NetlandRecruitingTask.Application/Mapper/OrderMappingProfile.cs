using AutoMapper;
using NetlandRecruitingTask.Application.Functions.Orders.Query.GetOrderList;
using NetlandRecruitingTask.Domain.Entity;
using System.Globalization;

namespace NetlandRecruitingTask.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        //Profil mapowania automappera
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}