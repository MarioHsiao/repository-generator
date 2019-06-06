using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface ISolutionCollapser
    {
        Task CollapseSolutionAsync();
    }
}
