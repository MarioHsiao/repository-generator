// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGenerator.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(IRepositoryGenerator))]
    public class RepositoryGenerator : IRepositoryGenerator
    {
        [ImportingConstructor]
        public RepositoryGenerator(
            [Import] IRepositoryGeneratorServices services)
        {
            Services = services;
        }

        public IRepositoryGeneratorServices Services { get; }

        public async Task CreateRepositoryAsync(IRepositoryGeneratorParameters parameters, CancellationToken cancellationToken = default)
        {
            string zipFilePath = Path.Combine(parameters.Output, "arcade.zip");
            string targetDirectory = Path.Combine(parameters.Output, parameters.RepositoryName);
            string solutionFilePath = Path.Combine(targetDirectory, $"{parameters.SolutionName}.sln");

            SlowlyRemoveAndRecreateDirectory(targetDirectory);

            await Services.Downloader.DownloadFileAsync(DownloadUrls.Arcade, zipFilePath);

            await Services.Expander.ExpandFileAsync(zipFilePath, targetDirectory);

            ProcessRun1(parameters, targetDirectory, solutionFilePath);

            var replacements = Services.Replace.Create(parameters);

            ProcessRun2(targetDirectory, replacements);

            if (File.Exists(solutionFilePath))
                await Services.Opener.OpenRepositoryAsync(solutionFilePath);
        }

        private void ProcessRun2(string targetDirectory, Dictionary<string, string> replacements)
        {
            var files = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories).Select(x => new FileInfo(x));
            foreach (var file in files)
            {
                ProcessFileInfo(file, replacements);
            }
        }

        private void ProcessRun1(IRepositoryGeneratorParameters parameters, string targetDirectory, string solutionFilePath)
        {
            var files = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories).Select(x => new FileInfo(x));

            foreach (var file in files)
            {
                switch (file.Name)
                {
                    case "ArcadeRepo.sln":
                        {
                            File.Copy(file.FullName, solutionFilePath);
                            File.Delete(file.FullName);
                            break;
                        }
                    case "ArcadeRepo.csproj":
                        {
                            string newDir = Path.Combine(targetDirectory, "src", parameters.ProjectName);
                            Directory.CreateDirectory(newDir);
                            string newPath = Path.Combine(targetDirectory, "src", parameters.ProjectName, $"{parameters.ProjectName}.csproj");
                            File.Move(file.FullName, newPath);
                            file.Directory.Delete(true);
                            break;
                        }
                }
            }
        }

        private static void SlowlyRemoveAndRecreateDirectory(string targetDirectory)
        {
            if (Directory.Exists(targetDirectory))
            {
                string[] files = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    File.Delete(file);
                }

                try
                {
                    Directory.Delete(targetDirectory, true);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                }
            }

            try
            {
                Directory.CreateDirectory(targetDirectory);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        private void ProcessFileInfo(FileInfo info, Dictionary<string, string> replacements)
        {
            string text = Services.Replace.Replace(File.ReadAllText(info.FullName), replacements);
            Logger.Log($"Processing file {info.Name}");
            File.WriteAllText(info.FullName, text);
        }
    }
}