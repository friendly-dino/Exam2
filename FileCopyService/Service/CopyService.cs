using FileCopyService.Interface;
namespace FileCopyService.Service
{
    public class CopyService(ILogger<CopyService> copyLogger) : ICopyService
    {
        private readonly ILogger<CopyService> _copyLogger = copyLogger;

        public Task CopyFromSource(CancellationToken stoppingToken)
        {
            //FileSystemWatcher watcher1 = new FileSystemWatcher();
            try
            {

                Random rnd = new();


                _copyLogger.LogInformation("test logging................" + rnd.Next(1, 99).ToString());
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _copyLogger.LogError(ex, "Error occured while copying");
                throw ex;
            }
        }
        public void CreateDir(string sourceFolder, string destinationFolder)
        {
            Directory.CreateDirectory(sourceFolder);
            Directory.CreateDirectory(destinationFolder);
        }
    }
}
