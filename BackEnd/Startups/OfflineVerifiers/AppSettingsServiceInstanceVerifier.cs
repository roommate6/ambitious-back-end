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
            if (string.IsNullOrEmpty(appSettingsService.Secrets.Database.Host))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:Database:Host - (exception) string.IsNullOrEmpty");
            }
            if (!Database.PortIsValid(appSettingsService.Secrets.Database.Port))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:Database:Port - (exception) !Database.PortIsValid");
            }
            if (string.IsNullOrEmpty(appSettingsService.Secrets.Database.User))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:Database:User - (exception) string.IsNullOrEmpty");
            }
            if (string.IsNullOrEmpty(appSettingsService.Secrets.Database.Password))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:Database:Password - (exception) string.IsNullOrEmpty");
            }
            if (string.IsNullOrEmpty(appSettingsService.Secrets.Database.Name))
            {
                exceptionMessagesBuffer.AppendLine("Secrets:Database:Name - (exception) string.IsNullOrEmpty");
            }

            return exceptionMessagesBuffer.ToString();
        }
    }
}