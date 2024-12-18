using caditec_back_end.Data.Models.Options.MediaService;
using caditec_back_end.Data.Models.Results.MediaService;

namespace caditec_back_end.Services.Interfaces
{
    public interface IMediaService
    {
        public Task<CreateMediaResult> CreateAsync(CreateMediaOptions options);
        //public Task<ReadMediaResult> Read(ReadMediaOptions options);
    }
}