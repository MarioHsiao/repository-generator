using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryDownloader
    {
        Task DownloadFileAsync(string address, string fileName);
    }
}
