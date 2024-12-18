namespace caditec_back_end.Data.Models.Options.MediaService
{
    public readonly struct CreateMediaOptions
    {
        public IFormFile File { get; init; }
        public string DirectoryPath { get; init; }
        public string FileName { get; init; }
        public CancellationToken CancellationToken { get; init; }
    }
}