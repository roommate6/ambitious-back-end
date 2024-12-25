using System.Text;
using BackEnd.Domain.CustomTypes.AppSettingsService;
using BackEnd.Services.Concretes;

namespace BackEnd.Startups.OfflineVerifiers
{
    public static class AppSettingsServiceInstanceVerifier
    {
        /// <summary>
        /// Static method to validate an instance of the AppSettingsService.
        /// It ensures that all properties of the instance are properly populated from the appsettings.json configuration file.
        /// Any exceptions encountered during the validation process are logged to the console.
        /// </summary>
        /// <param name="appSettingsService">The AppSettingsService instance to validate.</param>
        /// <returns>true(instance passed all the checks); false(otherwise)</returns>
        public static bool VerifyInstanceOfAppSettingsService(AppSettingsService appSettingsService)
        {
            StringBuilder exceptionMessagesBuffer = new("");

            exceptionMessagesBuffer.Append(VerifyPaths(appSettingsService));
            exceptionMessagesBuffer.Append(VerifyDatabase(appSettingsService));

            if (exceptionMessagesBuffer.Length > 0)
            {
                Console.Write(exceptionMessagesBuffer.ToString());
                return false;
            }

            return true;
        }

        private static string VerifyPaths(AppSettingsService appSettingsService)
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

            return exceptionMessagesBuffer.ToString();
        }

        private static string VerifyDatabase(AppSettingsService appSettingsService)
        {
            StringBuilder exceptionMessagesBuffer = new("");
            if (string.IsNullOrEmpty(appSettingsService.Secrets.DatabaseSettings.Host))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:DatabaseSettings:Host - (exception) string.IsNullOrEmpty");
            }
            if (!DatabaseSettings.PortIsValid(appSettingsService.Secrets.DatabaseSettings.Port))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:DatabaseSettings:Port - (exception) !Database.PortIsValid");
            }
            if (string.IsNullOrEmpty(appSettingsService.Secrets.DatabaseSettings.User))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:DatabaseSettings:User - (exception) string.IsNullOrEmpty");
            }
            if (string.IsNullOrEmpty(appSettingsService.Secrets.DatabaseSettings.Password))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:DatabaseSettings:Password - (exception) string.IsNullOrEmpty");
            }
            if (string.IsNullOrEmpty(appSettingsService.Secrets.DatabaseSettings.Name))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:DatabaseSettings:Name - (exception) string.IsNullOrEmpty");
            }

            return exceptionMessagesBuffer.ToString();
        }
    }
}