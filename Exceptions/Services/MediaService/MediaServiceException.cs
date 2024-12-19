namespace caditec_back_end.Exceptions.Services.MediaService
{
    [Serializable]
    public class MediaServiceException : Exception
    {
        public MediaServiceException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        { }
    }
}