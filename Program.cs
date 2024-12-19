using caditec_back_end.Services.Concretes;
using caditec_back_end.Startups;
using caditec_back_end.Startups.OfflineVerifiers;

var builder = WebApplication.CreateBuilder(args);
var appSettingsService = AppSettingsService.GetEmptyInstance();
builder.Configuration.Bind(appSettingsService);
if (!AppSettingsVerifier.VerifyAppSettingsConfiguration(appSettingsService))
{
    Environment.Exit(1);
}
builder.Services.AddEverythingCustomly(appSettingsService);

var app = builder.Build();
app.ConfigureEverythingCustomly();
app.Run();