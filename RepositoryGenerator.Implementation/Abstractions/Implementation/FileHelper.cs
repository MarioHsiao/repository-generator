using System.ComponentModel.Composition;
using System.IO;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IFileHelper))]
    public class FileHelper : IFileHelper
    {
        public void CopyDirectory(string source, string destination, bool overwrite = false, bool deleteSourceOnCompletion = false)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
                throw new DirectoryNotFoundException(source);

            var dirs = dir.GetDirectories();

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string targetPath = Path.Combine(destination, file.Name);
                Logger.Log($"Copying {file.Name} to {targetPath}");
                file.CopyTo(targetPath, overwrite);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destination, subdir.Name);
                CopyDirectory(subdir.FullName, temppath, overwrite, deleteSourceOnCompletion);
            }
        }

        public void DeleteIfExists(string path)
        {
            if (IsDirectory(path))
            {
                Directory.Delete(path, true);
            }
            else
            {
                File.Delete(path);
            }
        }

        private static bool IsDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}
