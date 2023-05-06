using Microsoft.Extensions.DependencyInjection;
using NetlandRecruitingTask.Application.Contracts;
using NetlandRecruitingTask.Infrastructure.Repositories;

namespace NetlandRecruitingTask.Infrastructure
{
    //Instalator zaleznosci warstwy Infrastructure
    //Klasa partial-czesciowa poniewaz kazda warstwa moze ja rozwijac
    public static partial class ApplicationInstaller
    {
        public static IServiceCollection InfrastructureProjectInstaller(this IServiceCollection services)
        {
            services.AddScoped<ICsvRepository, CsvRepository>();
            return services;
        }
    }
}