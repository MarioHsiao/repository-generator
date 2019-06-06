namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryGeneratorServices
    {
        IReplacementsService Replace { get; }

        IRepositoryOpener Opener { get; }

        IRepositoryDownloader Downloader { get; }

        IRepositoryExpander Expander { get; }
    }
}
