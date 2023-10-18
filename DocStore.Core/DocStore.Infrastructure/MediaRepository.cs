using System;
using System.IO;
using DocumentStore.Helpers;
using DocumentStore.Interfaces;

namespace DocStore.Infrastructure
{
    public class MediaRepository : IMediaRepository
    {
        public void ClearTempFiles(string filesPath, string fileId)
        {
            Require.NotNullOrEmpty(filesPath, "filePath is required");
            Require.NotNullOrEmpty(fileId, "fileId is required");
            if (!DirectoryExists(filesPath)) throw new ApplicationException("filePath does not exist");

            var dir = new DirectoryInfo(filesPath);
            foreach (var file in dir.EnumerateFiles(fileId + ".*")) file.Delete();
        }

        public bool DirectoryExists(string filesPath)
        {
            Require.NotNullOrEmpty(filesPath, "filePath is required");
            return Directory.Exists(filesPath);
        }

        public bool FileExists(string sourcePath)
        {
            Require.NotNullOrEmpty(sourcePath, "sourcePath is required");
            return File.Exists(sourcePath);
        }

        public void MoveFile(string sourceFilePath, string targetFilePath)
        {
            Require.NotNullOrEmpty(sourceFilePath, "sourceFilePath is required");
            Require.NotNullOrEmpty(targetFilePath, "targetFilePath is required");
            File.Move(sourceFilePath, targetFilePath);
        }
    }
}