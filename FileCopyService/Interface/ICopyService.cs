namespace FileCopyService.Interface
{
    public interface ICopyService
    {
        /// <summary>
        /// Ensures that the folder is created.
        /// </summary>
        /// <param name="sourceFolder">The source folder where the files are copied.</param>
        /// <param name="destinationFolder">The destination folder to paste the copied files.</param>
        void CreateDir(string sourceFolder, string destinationFolder);
        Task CopyFromSource(CancellationToken stoppingToken);
    }
}
