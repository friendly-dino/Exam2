using FileCopyService.Interface;

namespace FileCopyService.Service
{
    public class CopyService : ICopyService
    {
        public Task CopyFromSource(CancellationToken stoppingToken)
        {



            return Task.CompletedTask;


        }

        public void CreateDir(string sourceFolder, string destinationFolder)
        {
            Directory.CreateDirectory(sourceFolder);
            Directory.CreateDirectory(destinationFolder);
        }
    }
}
