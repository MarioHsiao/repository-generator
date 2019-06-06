// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGeneratorService.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IRepositoryGeneratorServices))]
    public class RepositoryGeneratorServices : IRepositoryGeneratorServices
    {
        [ImportingConstructor]
        public RepositoryGeneratorServices(
            //[Import] IGitHubBlobService blob,
            //[Import] IGitHubCommitService commit,
            //[Import] IGitHubRepositoryTreeService repositoryTree,
            //[Import] IBlobDecoder decoder,
            [Import] IReplacementsService replace,
            [Import] IRepositoryOpener opener,
            //[Import] IProgressDialogFactory dialog,
            [Import] IRepositoryDownloader downloader,
            [Import] IRepositoryExpander expander)
        {
            //Blob = blob;
            //Commit = commit;
            //RepositoryTree = repositoryTree;
            //Decoder = decoder;
            Replace = replace;
            Opener = opener;
            //Dialog = dialog;
            Downloader = downloader;
            Expander = expander;
        }

        //public IGitHubBlobService Blob { get; }
        //public IGitHubCommitService Commit { get; }
        //public IGitHubRepositoryTreeService RepositoryTree { get; }
        //public IBlobDecoder Decoder { get; }
        public IReplacementsService Replace { get; }
        public IRepositoryOpener Opener { get; }
        //public IProgressDialogFactory Dialog { get; }

        public IRepositoryDownloader Downloader { get; }

        public IRepositoryExpander Expander { get; }
    }
}