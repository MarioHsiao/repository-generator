// // -----------------------------------------------------------------------
// // <copyright file="IRepositoryGeneratorServices.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryGeneratorServices
    {
        //IGitHubBlobService Blob { get; }

        //IGitHubCommitService Commit { get; }

        //IGitHubRepositoryTreeService RepositoryTree { get; }

        //IBlobDecoder Decoder { get; }

        IReplacementsService Replace { get; }

        IRepositoryOpener Opener { get; }

        //IProgressDialogFactory Dialog { get; }

        IRepositoryDownloader Downloader { get; }

        IRepositoryExpander Expander { get; }
    }
}
