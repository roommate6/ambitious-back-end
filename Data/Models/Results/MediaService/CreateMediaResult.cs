namespace caditec_back_end.Data.Models.Results.MediaService
{
    public struct CreateMediaResult
    {
        public bool Success { get; init; }
        public string FilePath { get; init; }
        public string ErrorMessage { get; init; }
    }
}