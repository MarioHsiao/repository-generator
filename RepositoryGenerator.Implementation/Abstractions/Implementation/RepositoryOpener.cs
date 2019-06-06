// // -----------------------------------------------------------------------
// // <copyright file="RepositoryOpener.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using EnvDTE80;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Composition;
using System.IO;
using Task = System.Threading.Tasks.Task;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IRepositoryOpener))]
    public class RepositoryOpener : IRepositoryOpener
    {
        private const uint _addToCurrent = (uint)__VSSLNOPENOPTIONS.SLNOPENOPT_AddToCurrent;
        private readonly ISolutionCollapser _collapser;

        [ImportingConstructor]
        public RepositoryOpener(
            [Import] ISolutionCollapser collapser)
        {
            _collapser = collapser;
        }

        public async Task OpenRepositoryAsync(string solutionFilePath)
        {
            if (File.Exists(solutionFilePath))
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                await Logger.LogAsync($"Opening solution {solutionFilePath}...");
                Solution2.OpenSolutionFile(_addToCurrent, solutionFilePath);

                Solution4.EnsureSolutionIsLoaded((uint)__VSBSLFLAGS.VSBSLFLAGS_None);

                Solution2.SaveSolutionElement((uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_ForceSave, null, 0);

                await _collapser.CollapseSolutionAsync();
            }
            else
            {
                MessageDialog.Show("Solution File Error", $"The soution file {solutionFilePath} does not exist.", MessageDialogCommandSet.Ok);
            }
        }

        private static DTE2 DTE
            => GetService<SDTE, DTE2>();

        private static IVsSolution2 Solution2
                        => GetService<SVsSolution, IVsSolution2>();

        private static IVsSolution4 Solution4
                => GetService<SVsSolution, IVsSolution4>();

        private static TServiceInterface GetService<TService, TServiceInterface>()
        {
            return (TServiceInterface)Shell.Package.GetGlobalService(typeof(TService));
        }
    }
}