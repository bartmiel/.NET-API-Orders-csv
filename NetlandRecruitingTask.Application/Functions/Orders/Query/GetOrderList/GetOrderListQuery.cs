using MediatR;

namespace NetlandRecruitingTask.Application.Functions.Orders.Query.GetOrderList
{
    public class GetOrderListQuery : IRequest<IEnumerable<OrderDto>>
    {
        public string? OrderNumber { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public List<string>? ClientCodes { get; set; }
    }
}