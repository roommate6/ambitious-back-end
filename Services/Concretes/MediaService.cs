using caditec_back_end.Data.Models.Options.MediaService;
using caditec_back_end.Data.Models.Results.MediaService;
using caditec_back_end.Exceptions.Services.MediaService;
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

                string fullPath = Path.Combine(options.DirectoryPath, options.FormFile.FileName);
                if (File.Exists(fullPath))
                {
                    throw new FileAlreadyExistsException(options);
                }

                using (FileStream stream = new(fullPath, FileMode.Create))
                {
                    await options.FormFile.CopyToAsync(stream, options.CancellationToken ?? new CancellationToken());
                }

                result = new CreateMediaResult
                {
                    FilePath = fullPath
                };
            }
            catch (Exception exception)
            {
                result = new CreateMediaResult
                {
                    ExceptionMessage = exception.Message
                };
            }
            return result;
        }
    }
}
