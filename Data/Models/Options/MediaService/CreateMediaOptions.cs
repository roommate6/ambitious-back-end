namespace caditec_back_end.Data.Models.Options.MediaService
{
    public struct CreateMediaOptions
    {
        public required IFormFile FormFile { get; set; }
        public required string DirectoryPath { get; set; }
        public CancellationToken? CancellationToken { get; set; }
    }
}