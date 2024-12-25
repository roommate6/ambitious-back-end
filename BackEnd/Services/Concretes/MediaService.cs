using BackEnd.Domain.Options.MediaService;
using BackEnd.Domain.Results.MediaService;
using BackEnd.Exceptions.Services.MediaService;
using BackEnd.Services.Interfaces;

namespace BackEnd.Services.Concretes
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
                if (File.Exists(fullPath))
                {
                    throw new FileAlreadyExistsException(options);
                }

                using (FileStream stream = new(fullPath, FileMode.Create))
                {
                    await stream.WriteAsync(options.Content, options.CancellationToken ?? new CancellationToken());
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
