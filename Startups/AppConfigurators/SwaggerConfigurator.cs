namespace caditec_back_end.Startups.AppConfigurators
{
    public static class SwaggerConfigurator
    {
        public static WebApplication ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}