using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using NetlandRecruitingTask.Application.Contracts;
using NetlandRecruitingTask.Domain.Entity;

namespace NetlandRecruitingTask.Application.Functions.Orders.Query.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IEnumerable<OrderDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICsvRepository _csvRepository;
        private readonly string _csvFilePath;

        public GetOrderListQueryHandler(IMapper mapper, ICsvRepository csvRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _csvRepository = csvRepository;
            //Pobieram sciezke do pliku csv z appsettings.json
            _csvFilePath = configuration.GetValue<string>("CSVFileConfiguration:CsvFilePath");
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            //Wczytywanie danych z csv
            var orders = await _csvRepository.ReadCSVAsync<Order>(_csvFilePath);

            //Filtrowanie danych
            if(request.OrderNumber != null)
                orders = orders.Where(o => o.Number == request.OrderNumber).ToList();

            if(request.OrderDateFrom != null)
                orders = orders.Where(o => o.OrderDate >= request.OrderDateFrom).ToList();

            if(request.OrderDateTo != null)
                orders = orders.Where(o => o.OrderDate <= request.OrderDateTo).ToList();

            if(request.ClientCodes != null && request.ClientCodes.Count >0)
                orders = orders.Where(o => request.ClientCodes.Contains(o.ClientCode)).ToList();

            //Zwracanie zmapowanych i odfiltrowanych danych
            //Mapowanie nie jest konieczne, ale przydatne gdybym nie chcial zwracac jakiegos pola uzytkownikom.
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}