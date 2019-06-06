// // -----------------------------------------------------------------------
// // <copyright file="IRepositoryGenerator.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryGenerator
    {
        IRepositoryGeneratorServices Services { get; }

        Task CreateRepositoryAsync(IRepositoryGeneratorParameters parameters, CancellationToken cancellationToken = default);
    }
}