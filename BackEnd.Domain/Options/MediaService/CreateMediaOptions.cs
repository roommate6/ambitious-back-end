namespace BackEnd.Domain.Options.MediaService
{
    public struct CreateMediaOptions
    {
        public required string DirectoryPath { get; set; }
        public required string FileName { get; set; }
        public required byte[] Content { get; set; }
        public CancellationToken? CancellationToken { get; set; }
    }
}