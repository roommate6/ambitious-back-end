namespace caditec_back_end.Startups.DependencyInjectors
{
    public static class BasicServicesInjector
    {
        public static IServiceCollection AddBasicServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}