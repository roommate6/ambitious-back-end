using BackEnd.Services.Concretes;
using BackEnd.Startups.DependencyInjectors;

namespace BackEnd.Startups
{
    public static class MainDependencyInjectionStartup
    {
        public static IServiceCollection AddEverythingCustomly(this IServiceCollection services, AppSettingsService appSettingsService)
        {
            services.AddAppSettingsService(appSettingsService);
            services.AddBasicServices();
            services.AddSingletons();

            return services;
        }
    }
}