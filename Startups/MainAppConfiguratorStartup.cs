using caditec_back_end.Startups.AppConfigurators;

namespace caditec_back_end.Startups
{
    public static class AppConfiguration
    {
        public static WebApplication ConfigureEverythingCustomly(this WebApplication app)
        {
            app.ConfigureSwagger();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}