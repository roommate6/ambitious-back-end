using BackEnd.Domain.Options.MediaService;
using BackEnd.Domain.Results.MediaService;

namespace BackEnd.Services.Interfaces
{
    public interface IMediaService
    {
        public Task<CreateMediaResult> CreateAsync(CreateMediaOptions options);
        //public Task<ReadMediaResult> Read(ReadMediaOptions options);
    }
}