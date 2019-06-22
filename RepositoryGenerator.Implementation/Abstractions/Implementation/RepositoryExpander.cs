using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IRepositoryExpander))]
    public class RepositoryExpander : IRepositoryExpander
    {
        private readonly IFileHelper _fileHelper;

        [ImportingConstructor]
        public RepositoryExpander(
            [Import] IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public async Task ExpandFileAsync(string zipFile, string outputDirectory)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            string tempGuid = Guid.NewGuid().ToString("N");

            string tempZipDir =
                Path.Combine(Path.GetDirectoryName(zipFile), tempGuid);

            await Logger.LogAsync($"Unzipping file {zipFile} to directory {outputDirectory}");

            ZipFile.ExtractToDirectory(zipFile, tempZipDir);

            var firstDirectory = Directory.GetDirectories(tempZipDir).SingleOrDefault();

            try
            {
                _fileHelper.CopyDirectory(firstDirectory, outputDirectory, true, true);
            }
            catch (Exception ex)
            {
                await Logger.LogAsync(ex.Message);
            }

            if (Directory.Exists(tempZipDir))
                Directory.Delete(tempZipDir, true);

            if (File.Exists(zipFile))
                File.Delete(zipFile);
        }
    }
}
