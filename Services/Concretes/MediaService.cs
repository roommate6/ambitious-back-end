using caditec_back_end.Data.Models.Options.MediaService;
using caditec_back_end.Data.Models.Results.MediaService;
using caditec_back_end.Services.Interfaces;

namespace caditec_back_end.Services.Concretes
{
    public class MediaService : IMediaService
    {
        public async Task<CreateMediaResult> CreateAsync(CreateMediaOptions options)
        {
            CreateMediaResult result;
            try
            {
                if (!Directory.Exists(options.DirectoryPath))
                {
                    Directory.CreateDirectory(options.DirectoryPath);
                }

                string fullPath = Path.Combine(options.DirectoryPath, options.FileName);

                using (FileStream stream = new(fullPath, FileMode.Create))
                {
                    await options.File.CopyToAsync(stream, options.CancellationToken);
                }

                result = new CreateMediaResult
                {
                    Success = true,
                    FilePath = fullPath
                };
            }
            catch (Exception exception)
            {
                result = new CreateMediaResult
                {
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
            return result;
        }
    }
}
