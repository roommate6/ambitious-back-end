using BackEnd.Startups.AppConfigurators;

namespace BackEnd.Startups
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