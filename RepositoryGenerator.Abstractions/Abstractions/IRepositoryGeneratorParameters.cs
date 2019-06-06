namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IRepositoryGeneratorParameters
    {
        string Description { get; set; }
        string Output { get; set; }
        string ProjectName { get; set; }
        string RepositoryName { get; set; }
        RepositoryStyle RepositoryStyle { get; set; }
        string RootNamespace { get; set; }
        SdkXmlElementLocation SdkXmlLocation { get; set; }
        string SolutionName { get; set; }
        TargetFramework TargetFramework { get; set; }
    }
}