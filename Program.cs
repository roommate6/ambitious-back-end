using caditec_back_end.Data.Models.Options.MediaService;
using caditec_back_end.Services.Concretes;
using caditec_back_end.Services.Interfaces;
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

var formFile = new FormFile(new MemoryStream(System.Text.Encoding.UTF8.GetBytes("Test value aaa22")), 0, 16, "Data", "test.txt");
var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(10));

var createMediaOptions = new CreateMediaOptions
{
    FormFile = formFile,
    DirectoryPath = app.Services.GetRequiredService<IAppSettingsService>().Configurations.Paths.MediaStorage,
    CancellationToken = cts.Token
};

var result = await app.Services.GetRequiredService<IMediaService>().CreateAsync(createMediaOptions);
Console.WriteLine(result.FilePath ?? result.ExceptionMessage);


app.Run();