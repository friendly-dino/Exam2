namespace FileCopyService.Interface
{
    internal interface ICopyService
    {
        Task CreateDir();
        Task CopyFromSource();
    }
}
