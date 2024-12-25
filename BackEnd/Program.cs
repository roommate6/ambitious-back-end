using BackEnd.Services.Concretes;
using BackEnd.Startups;
using BackEnd.Startups.OfflineVerifiers;

#region Create builder and AppSettingsService instance

var builder = WebApplication.CreateBuilder(args);
var appSettingsService = AppSettingsService.GetEmptyInstance();

#endregion

builder.Configuration.Bind(appSettingsService);

#region Test AppSettingsService instance after the binding

if (!AppSettingsServiceInstanceVerifier
    .VerifyInstanceOfAppSettingsService(appSettingsService))
{
    appSettingsService = null;
    builder = null;
    Environment.Exit(1);
}

#endregion

builder.Services.AddEverythingCustomly(appSettingsService);

#region Build, configure and run the app

var app = builder.Build();
app.ConfigureEverythingCustomly();
app.Run();

#endregion
