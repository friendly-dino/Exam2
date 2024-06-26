using FileCopyService.Interface;
using FileCopyService.Service;
using Serilog;
namespace FileCopyService
{
    public static class ServiceRegistration
    {
        public static HostApplicationBuilder AddRequiredServices(this HostApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
           .WriteTo.File(AppSettingHelper.GetValue("Folders:Log"), rollingInterval: RollingInterval.Hour)
           .WriteTo.EventLog("FileCopyService", manageEventSource: true)
           .CreateLogger();

            builder.Logging.ClearProviders().AddSerilog();
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddSingleton<ICopyService, CopyService>();

            return builder;
        }
    }
}
