using BackEnd.Domain.CustomTypes.AppSettingsService;

namespace BackEnd.Services.Interfaces
{
    public interface IAppSettingsService
    {
        public Configurations Configurations { get; set; }
        public Secrets Secrets { get; set; }
    }
}