using caditec_back_end.Data.Models.Options.MediaService;
using caditec_back_end.Services.Concretes;
using caditec_back_end.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMediaService, MediaService>();

var app = builder.Build();

var file = new FormFile(new MemoryStream(System.Text.Encoding.UTF8.GetBytes("Test value aaa22")), 0, 16, "Data", "test.txt");
var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(10));

var createMediaOptions = new CreateMediaOptions
{
    File = file,
    FileName = "test.txt",
    DirectoryPath = ".",
    CancellationToken = cts.Token
};

var result = await app.Services.GetRequiredService<IMediaService>().CreateAsync(createMediaOptions);
Console.WriteLine(result.Success);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();