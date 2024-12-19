using caditec_back_end.Data.Models.CustomTypes.AppSettingsService;
using caditec_back_end.Services.Interfaces;

namespace caditec_back_end.Services.Concretes
{
    public class AppSettingsService : IAppSettingsService
    {
        public required Configurations Configurations { get; set; }

        public static AppSettingsService GetEmptyInstance()
        {
            return new AppSettingsService()
            {
                Configurations = new()
                {
                    Paths = new()
                    {
                        MediaStorage = ""
                    }
                }
            };
        }
    }
}