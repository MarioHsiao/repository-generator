// // -----------------------------------------------------------------------
// // <copyright file="ReplacementsService.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IReplacementsService))]
    public class ReplacementsService : IReplacementsService
    {
        public Dictionary<string, string> Create(IRepositoryGeneratorParameters parameters)
        {
            return CreateReplacementsDictionary(
                parameters.ProjectName,
                parameters.Description,
                parameters.RootNamespace,
                parameters.RepositoryName,
                parameters.TargetFramework);
        }

        public string Replace(string input, Dictionary<string, string> replacements)
        {
            string retVal = input;
            foreach (var kvp in replacements)
            {
                retVal = retVal.Replace(kvp.Key, kvp.Value);
            }

            return retVal;
        }

        private Dictionary<string, string> CreateReplacementsDictionary(
            string name,
            string description,
            string defaultNamespace,
            string repositoryName,
            TargetFramework targetFramework)
        {
            string tf = string.Empty;
            switch (targetFramework)
            {
                case TargetFramework.Net_472:
                    tf = "net472";
                    break;
                case TargetFramework.NetStandard_2_0:
                    tf = "netstandard2.0";
                    break;
                case TargetFramework.NetCoreApp_2_0:
                    tf = "netcoreapp2.0";
                    break;
                case TargetFramework.NetCoreApp_2_1:
                    tf = "netcoreapp2.1";
                    break;
                case TargetFramework.NetCoreApp_2_2:
                    tf = "netcoreapp2.2";
                    break;
                case TargetFramework.NetCoreApp_3_0:
                    tf = "netcoreapp3.0";
                    break;
            }

            return new Dictionary<string, string>
            {
                ["{{name}}"] = name,
                ["{{repositoryName}}"] = repositoryName,
                ["{{targetFramework}}"] = tf,
                ["{{defaultNamespace}}"] = defaultNamespace,
                ["{{description}}"] = description,
                ["{{codeGeneratorGuid}}"] = GenerateGuid(),
                ["{{buildGuid}}"] = GenerateGuid(),
                ["{{toolsGuid}}"] = GenerateGuid(),
                ["{{arcadeRepoGuid}}"] = GenerateGuid(),
                ["{{solutionGuid}}"] = GenerateGuid()
            };
        }

        private static string GenerateGuid() => Guid.NewGuid().ToString("B").ToUpper();
    }
}