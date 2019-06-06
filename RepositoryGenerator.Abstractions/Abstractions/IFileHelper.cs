namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IFileHelper
    {
        void DeleteIfExists(string path);

        void CopyDirectory(string source, string destination, bool overwrite = false, bool deleteSourceOnCompletion = false);
    }
}
