namespace BackEnd.Domain.CustomTypes.AppSettingsService
{
    public struct DatabaseSettings
    {
        public required string Host { get; set; }
        public required int Port { get; set; }
        public required string User { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }

        #region Static properties and methods for port validation

        public static readonly int MinValidPortValue = 1025;
        public static readonly int MaxValidPortValue = 9999;

        public static bool PortIsValid(int port)
        {
            if (port < MinValidPortValue || port > MaxValidPortValue)
            {
                return false;
            }
            return true;
        }

        public static int GetRandomInvalidPort()
        {
            return new Random().Next(int.MinValue, MinValidPortValue);
        }

        #endregion
    }
}