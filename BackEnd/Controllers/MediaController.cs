using BackEnd.Domain.Options.MediaService;
using BackEnd.Domain.Results.MediaService;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IAppSettingsService _appSettingsService;
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService, IAppSettingsService appSettingsService)
        {
            _appSettingsService = appSettingsService;
            _mediaService = mediaService;
        }

        [HttpPost()]
        public async Task<ActionResult<string>> Create(IFormFile body)
        {
            byte[] mediaBytes;

            CancellationTokenSource cancellationTokenSource;
            using (var memoryStream = new MemoryStream())
            {
                cancellationTokenSource = new CancellationTokenSource
                    (TimeSpan.FromSeconds(2));
                await body.CopyToAsync(memoryStream, cancellationTokenSource.Token);
                mediaBytes = memoryStream.ToArray();
            }

            cancellationTokenSource = new CancellationTokenSource
                                (TimeSpan.FromSeconds(2));
            CreateMediaOptions options = new()
            {
                DirectoryPath = _appSettingsService.Configurations.Paths.MediaStorage,
                FileName = body.FileName,
                Content = mediaBytes,
                CancellationToken = cancellationTokenSource.Token
            };

            CreateMediaResult result = await _mediaService.CreateAsync(options);

            return Ok(_appSettingsService.Configurations.Paths.MediaStorage + ": " + (result.FilePath ?? result.ExceptionMessage));
        }
    }
}