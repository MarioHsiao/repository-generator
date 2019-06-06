using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IRepositoryGeneratorServices))]
    public class RepositoryGeneratorServices : IRepositoryGeneratorServices
    {
        [ImportingConstructor]
        public RepositoryGeneratorServices(
            [Import] IReplacementsService replace,
            [Import] IRepositoryOpener opener,
            [Import] IRepositoryDownloader downloader,
            [Import] IRepositoryExpander expander)
        {
            Replace = replace;
            Opener = opener;
            Downloader = downloader;
            Expander = expander;
        }

        public IReplacementsService Replace { get; }
        public IRepositoryOpener Opener { get; }
        public IRepositoryDownloader Downloader { get; }
        public IRepositoryExpander Expander { get; }
    }
}