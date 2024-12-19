using caditec_back_end.Services.Concretes;
using caditec_back_end.Startups.DependencyInjectors;

namespace caditec_back_end.Startups
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