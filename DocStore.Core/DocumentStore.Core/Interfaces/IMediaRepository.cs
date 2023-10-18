namespace DocumentStore.Interfaces
{
    public interface IMediaRepository
    {
        bool DirectoryExists(string filesPath);
        bool FileExists(string sourcePath);
        void MoveFile(string sourceFilePath, string targetFilePath);
        void ClearTempFiles(string filesPath, string fileId);
    }
}