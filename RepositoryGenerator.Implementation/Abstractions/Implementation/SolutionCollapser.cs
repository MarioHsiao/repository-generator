using EnvDTE;
using EnvDTE80;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(ISolutionCollapser))]
    public class SolutionCollapser : ISolutionCollapser
    {
        private readonly EnvDTE80.DTE2 _dte;

        [ImportingConstructor]
        public SolutionCollapser(
            [Import] DTE2 dte)
        {
            _dte = dte;
        }

        public async Task CollapseSolutionAsync()
        {
            await VisualStudio.Shell.ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            UIHierarchy solutionExplorer = _dte.ToolWindows.SolutionExplorer;
            if (solutionExplorer.UIHierarchyItems.Count <= 0)
                return;
            UIHierarchyItem rootNode = solutionExplorer.UIHierarchyItems.Item(1);
            Collapse(rootNode, ref solutionExplorer);
            rootNode.Select(vsUISelectionType.vsUISelectionTypeSelect);
            rootNode.DTE.SuppressUI = false;
        }

        public void Collapse(UIHierarchyItem item, ref UIHierarchy solutionExplorer)
        {
            foreach (UIHierarchyItem innerItem in item.UIHierarchyItems)
            {
                if (innerItem.UIHierarchyItems.Count > 0)
                {
                    Collapse(innerItem, ref solutionExplorer);
                    if (innerItem.UIHierarchyItems.Expanded)
                    {
                        innerItem.UIHierarchyItems.Expanded = false;
                        if (innerItem.UIHierarchyItems.Expanded)
                        {
                            innerItem.Select(vsUISelectionType.vsUISelectionTypeSelect);
                            solutionExplorer.DoDefaultAction();
                        }
                    }
                }
            }
        }
    }
}
