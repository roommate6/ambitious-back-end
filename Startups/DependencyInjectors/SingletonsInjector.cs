using caditec_back_end.Services.Concretes;
using caditec_back_end.Services.Interfaces;

namespace caditec_back_end.Startups.DependencyInjectors
{
    public static class SingletonsInjector
    {
        public static IServiceCollection AddAppSettingsService(this IServiceCollection services, AppSettingsService appSettingsService)
        {
            services.AddSingleton<IAppSettingsService>(appSettingsService);

            return services;
        }

        public static IServiceCollection AddSingletons(this IServiceCollection services)
        {
            services.AddSingleton<IMediaService, MediaService>();

            return services;
        }
    }
}