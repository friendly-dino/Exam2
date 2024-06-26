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
                    string destFile = Path.Combine(destinationFolder, Path.GetFileName(item));
                    FileCopy(item, destFile, true);
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _copyLogger.LogError(ex, "Error occured while copying.");
                throw;
            }
        }

        public async void CopyFile(FileSystemEventArgs e, string destinationFolder)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
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
                string destFile = Path.Combine(destinationFolder, Path.GetFileName(e.FullPath));
                FileCopy(e.FullPath, destFile, true);
            }
            catch (Exception ex)
            {
                _copyLogger.LogError(ex, "Error copying file {SourceFile}", e.FullPath);
            }
        }
        private void FileCopy(string sourceFileName, string destFileName, bool IsOverwrite)
        {
            ///tring destFile = Path.Combine(destinationFolder, Path.GetFileName(e.FullPath));
            File.Copy(sourceFileName, destFileName, IsOverwrite);
            _copyLogger.LogInformation("Copied file {SourceFile} to {DestinationFile}", sourceFileName, destFileName);
        }
    }
}
