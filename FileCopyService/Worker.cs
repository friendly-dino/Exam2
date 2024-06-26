using FileCopyService.Interface;

namespace FileCopyService
{
    public class Worker(ILogger<Worker> logger, ICopyService copyService) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly ICopyService _copyService = copyService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string sFolder = AppSettingHelper.GetValue("Folders:Source");
            string dFolder = AppSettingHelper.GetValue("Folders:Destination");

            //ensure to copy folder contents on first run if there are files in it
            if (!_copyService.IsFolderEmpty(sFolder)) await _copyService.CopyFile(sFolder, dFolder);

            _copyService.CreateDir(sFolder, dFolder);

            FileSystemWatcher watcher1 = new()
            {
                Path = sFolder,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };
            watcher1.Created += (sender, e) => _copyService.OnChanged(e, dFolder);
            watcher1.EnableRaisingEvents = true;

            #region UPDATE LOG FILE
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Copying service running at: {time}", DateTimeOffset.Now);

                    if (_copyService.IsFolderEmpty(sFolder))
                        _logger.LogInformation("Source folder is empty.");
                }
                //update the log file every 10s
                await Task.Delay(10000, stoppingToken);
            }
            #endregion
        }
    }
}
