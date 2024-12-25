using BackEnd.Domain.CustomTypes.AppSettingsService;
using BackEnd.Services.Interfaces;

namespace BackEnd.Services.Concretes
{
    public class AppSettingsService : IAppSettingsService
    {
        public required Configurations Configurations { get; set; }
        public required Secrets Secrets { get; set; }

        public static AppSettingsService GetEmptyInstance()
        {
            return new AppSettingsService()
            {
                Configurations = new()
                {
                    Paths = new()
                    {
                        MediaStorage = string.Empty
                    }
                },
                Secrets = new()
                {
                    DatabaseSettings = new()
                    {
                        Host = string.Empty,
                        Port = DatabaseSettings.GetRandomInvalidPort(),
                        User = string.Empty,
                        Password = string.Empty,
                        Name = string.Empty
                    }
                }
            };
        }
    }
}