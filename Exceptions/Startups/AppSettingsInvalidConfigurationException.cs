namespace caditec_back_end.Exceptions.Startups
{
    [Serializable]
    public class AppSettingsInvalidConfigurationException : StartupException
    {
        public AppSettingsInvalidConfigurationException(string message = "The file \"appsettings.json\" is invalid configured.", Exception? innerException = null)
                    : base(message, innerException)
        { }
    }
}