namespace FileCopyService.Interface
{
    public interface ICopyService
    {
        void CreateDir(string sourceFolder, string destinationFolder);
        Task CopyFromSource(CancellationToken stoppingToken);
    }
}
