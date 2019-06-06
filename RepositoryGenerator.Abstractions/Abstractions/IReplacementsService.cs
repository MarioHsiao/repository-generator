// // -----------------------------------------------------------------------
// // <copyright file="IReplacementsService.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IReplacementsService
    {
        Dictionary<string, string> Create(IRepositoryGeneratorParameters parameters);

        string Replace(string input, Dictionary<string, string> replacements);
    }
}