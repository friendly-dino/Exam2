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
        Task CopyFile(string sourceFolder, string destinationFolder);
        void OnChanged(FileSystemEventArgs e, string destinationFolder);
        bool IsFolderEmpty(string path);
    }
}
