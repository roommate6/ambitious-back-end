using BackEnd.Domain.Options.MediaService;

namespace BackEnd.Exceptions.Services.MediaService
{
    [Serializable]
    public class FileAlreadyExistsException : MediaServiceException
    {
        public FileAlreadyExistsException(string message = "File already exists.", Exception? innerException = null)
            : base(message, innerException)
        { }

        public FileAlreadyExistsException(CreateMediaOptions options, Exception? innerException = null)
            : base($"The file \"{options.FileName}\" already exists inside the directory \"{options.DirectoryPath}\".",
            innerException)
        {
        }
    }
}