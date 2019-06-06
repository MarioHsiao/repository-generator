using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryExpander
    {
        Task ExpandFileAsync(string zipFile, string outputDirectory);
    }
}
