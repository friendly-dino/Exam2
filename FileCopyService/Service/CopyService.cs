using FileCopyService.Interface;

namespace FileCopyService.Service
{
    public class CopyService(ILogger<CopyService> copyLogger) : ICopyService
    {
        private readonly ILogger<CopyService> _copyLogger = copyLogger;

        public Task CopyFile(string sourceFolder, string destinationFolder)
        {
            try
            {
                foreach (var item in Directory.GetFiles(sourceFolder))
                {
                    FileCopy(item, destinationFolder, true);
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _copyLogger.LogError(ex, "Error occured while copying.");
                throw;
            }
        }
        public void CreateDir(string sourceFolder, string destinationFolder)
        {
            Directory.CreateDirectory(sourceFolder);
            Directory.CreateDirectory(destinationFolder);
        }
        public bool IsFolderEmpty(string path)
        {
            return Directory.GetFiles(path).Length == 0;
        }

        public async void OnChanged(FileSystemEventArgs e, string destinationFolder)
        {
            try
            {
                //added delay to avoid IOException
                await Task.Delay(1000);
                FileCopy(e.FullPath, destinationFolder, true);
            }
            catch (Exception ex)
            {
                _copyLogger.LogError(ex, "Error copying file {SourceFile}", e.FullPath);
            }
        }
        private void FileCopy(string sourceFileName, string destinationFolder, bool IsOverwrite)
        {
            string destFileName = Path.Combine(destinationFolder, Path.GetFileName(sourceFileName));
            File.Copy(sourceFileName, destFileName, IsOverwrite);
            _copyLogger.LogInformation("Copied file {SourceFile} to {DestinationFile}", sourceFileName, destFileName);
        }
    }
}
