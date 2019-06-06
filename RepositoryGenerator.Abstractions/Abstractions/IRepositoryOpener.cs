// // -----------------------------------------------------------------------
// // <copyright file="IRepositoryOpener.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryOpener
    {
        Task OpenRepositoryAsync(string solutionFilePath);
    }
}