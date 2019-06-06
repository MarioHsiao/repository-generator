using System.ComponentModel.Composition;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IRepositoryDownloader))]
    public class RepositoryDownloader : IRepositoryDownloader
    {
        public async Task DownloadFileAsync(string address, string fileName)
        {
            WebClient client = new WebClient();

            try
            {
                await Logger.LogAsync($"Downloading file {address}...");

                client.DownloadFile(address, fileName);
            }
            catch (WebException ex)
            {
                await Logger.LogAsync(ex.Message);
            }

            await Task.CompletedTask;
        }
    }
}
