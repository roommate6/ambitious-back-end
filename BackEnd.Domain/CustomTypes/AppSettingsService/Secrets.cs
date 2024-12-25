namespace BackEnd.Domain.CustomTypes.AppSettingsService
{
    public struct Secrets
    {
        public required DatabaseSettings DatabaseSettings { get; set; }
    }
}