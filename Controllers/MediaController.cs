using caditec_back_end.Data.Models.Options.MediaService;
using caditec_back_end.Data.Models.Results.MediaService;
using caditec_back_end.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caditec_back_end.Controllers
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
            CreateMediaOptions options = new()
            {
                FormFile = body,
                DirectoryPath = _appSettingsService.Configurations.Paths.MediaStorage
            };

            CreateMediaResult result = await _mediaService.CreateAsync(options);

            return Ok(_appSettingsService.Configurations.Paths.MediaStorage + ": " + (result.FilePath ?? result.ExceptionMessage));
        }
    }
}