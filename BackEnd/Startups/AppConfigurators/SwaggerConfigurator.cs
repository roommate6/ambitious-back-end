namespace BackEnd.Startups.AppConfigurators
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