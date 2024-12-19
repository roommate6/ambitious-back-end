using caditec_back_end.Data.Models.CustomTypes.AppSettingsService;

namespace caditec_back_end.Services.Interfaces
{
    public interface IAppSettingsService
    {
        public Configurations Configurations { get; set; }
    }
}