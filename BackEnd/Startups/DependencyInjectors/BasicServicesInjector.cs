namespace BackEnd.Startups.DependencyInjectors
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