using CsvHelper.Configuration;
using NetlandRecruitingTask.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace NetlandRecruitingTask.Infrastructure.Repositories
{
    public sealed class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(o => o.Number).Validate(args => !string.IsNullOrEmpty(args.Field));
            Map(o => o.ClientCode).Validate(args => !string.IsNullOrEmpty(args.Field));
            Map(o => o.ClientName).Validate(args => !string.IsNullOrEmpty(args.Field));
            Map(o => o.OrderDate).TypeConverterOption.Format("dd.MM.yyyy").Validate(args => args.Field != null);
            Map(o => o.ShipmentDate).TypeConverterOption.Format("dd.MM.yyyy").Optional();
            Map(o => o.Quantity).Validate(args => args.Field != null);
            Map(o => o.Confirmed).Validate(args => args.Field != null);
            Map(o => o.Value).Validate(args => args.Field != null);
        }
    }
}