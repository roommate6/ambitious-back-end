using System.Text;
using caditec_back_end.Exceptions.Startups;
using caditec_back_end.Services.Concretes;

namespace caditec_back_end.Startups.OfflineVerifiers
{
    public static class AppSettingsVerifier
    {
        public static bool VerifyAppSettingsConfiguration(AppSettingsService appSettingsService)
        {
            try
            {
                VerifyPaths(appSettingsService);
            }
            catch (AppSettingsInvalidConfigurationException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

            return true;
        }

        private static void VerifyPaths(AppSettingsService appSettingsService)
        {
            string mediaStoragePath = appSettingsService.Configurations.Paths.MediaStorage;

            StringBuilder exceptionMessagesBuffer = new("");
            if (string.IsNullOrEmpty(mediaStoragePath))
            {
                exceptionMessagesBuffer.AppendLine("Configurations:Paths:MediaStorage - (exception) string.IsNullOrEmpty");
            }
            else if (!Directory.Exists(mediaStoragePath))
            {
                exceptionMessagesBuffer.AppendLine("Configurations:Paths:MediaStorage - (exception) !Directory.Exists");
            }

            if (exceptionMessagesBuffer.Length == 0)
            {
                return;
            }
            exceptionMessagesBuffer.Remove(exceptionMessagesBuffer.Length - 1, 1);
            throw new AppSettingsInvalidConfigurationException(exceptionMessagesBuffer.ToString());
        }
    }
}