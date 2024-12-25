namespace BackEnd.Domain.Results.MediaService
{
    public struct CreateMediaResult
    {
        public string? FilePath { get; set; }
        public string? ExceptionMessage { get; set; }
    }
}