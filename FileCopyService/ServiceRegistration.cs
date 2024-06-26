using FileCopyService.Interface;
using FileCopyService.Service;
using Microsoft.Extensions.Logging.EventLog;

namespace FileCopyService
{
    public static class ServiceRegistration
    {
        public static HostApplicationBuilder AddRequiredServices(this HostApplicationBuilder builder)
        {
            builder.Logging.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Information);
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddSingleton<ICopyService, CopyService>();

            return builder;
        }
    }
}
