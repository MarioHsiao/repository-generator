using System.Collections.Generic;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryTemplate
    {
        IReadOnlyList<Replacement> Replacements { get; }
    }

    public class Replacement
    {
        public Replacement(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }

    public class RepositoryProject
    {
        public string DirectoryName { get; set; }

        public string FileName { get; set; }
    }
}
