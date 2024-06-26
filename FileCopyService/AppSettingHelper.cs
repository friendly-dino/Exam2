namespace FileCopyService
{

    public static class AppSettingHelper
    {
        private static IConfigurationRoot configuration;
        static AppSettingHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }

        public static string GetValue(string key)
        {
            return configuration[key];
        }
    }
}
