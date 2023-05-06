using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NetlandRecruitingTask.Application
{
    //Instalator paczek NuGet z warstwy Application
    //Klasa partial-czesciowa poniewaz kazda warstwa moze ja rozwijac
    public static partial class ApplicationInstaller
    {
        public static IServiceCollection ApplicationProjectInstaller(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}