using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    [Export(typeof(DTE2))]
    public class VsDTE2 : DTE2
    {
        private readonly DTE2 _dte;

        public VsDTE2(DTE2 dte)
        {
            _dte = dte;
        }

        [ImportingConstructor]
        private VsDTE2()
            : this(GetService<SDTE, DTE2>())
        {
        }

        private static TServiceInterface GetService<TService, TServiceInterface>()
        {
            return (TServiceInterface)Shell.Package.GetGlobalService(typeof(TService));
        }

        public void Quit()
        {
            _dte.Quit();
        }

        public object GetObject(string Name)
        {
            return _dte.GetObject(Name);
        }

        public Window OpenFile(string ViewKind, string FileName)
        {
            return _dte.OpenFile(ViewKind, FileName);
        }

        public void ExecuteCommand(string CommandName, string CommandArgs = "")
        {
            _dte.ExecuteCommand(CommandName, CommandArgs);
        }

        public wizardResult LaunchWizard(string VSZFile, ref object[] ContextParams)
        {
            return _dte.LaunchWizard(VSZFile, ref ContextParams);
        }

        public string SatelliteDllPath(string Path, string Name)
        {
            return _dte.SatelliteDllPath(Path, Name);
        }

        public uint GetThemeColor(vsThemeColors Element)
        {
            return _dte.GetThemeColor(Element);
        }

        public string Name
        {
            get
            {
                return _dte.Name;
            }
        }

        public string FileName
        {
            get
            {
                return _dte.FileName;
            }
        }

        public string Version
        {
            get
            {
                return _dte.Version;
            }
        }

        public object CommandBars
        {
            get
            {
                return _dte.CommandBars;
            }
        }

        public Windows Windows
        {
            get
            {
                return _dte.Windows;
            }
        }

        public Events Events
        {
            get
            {
                return _dte.Events;
            }
        }

        public AddIns AddIns
        {
            get
            {
                return _dte.AddIns;
            }
        }

        public Window MainWindow
        {
            get
            {
                return _dte.MainWindow;
            }
        }

        public Window ActiveWindow
        {
            get
            {
                return _dte.ActiveWindow;
            }
        }

        public vsDisplay DisplayMode
        {
            get
            {
                return _dte.DisplayMode;
            }

            set
            {
                _dte.DisplayMode = value;
            }
        }

        public Solution Solution
        {
            get
            {
                return _dte.Solution;
            }
        }

        public Commands Commands
        {
            get
            {
                return _dte.Commands;
            }
        }

        public Properties get_Properties(string Category, string Page)
        {
            return _dte.get_Properties(Category, Page);
        }

        public SelectedItems SelectedItems
        {
            get
            {
                return _dte.SelectedItems;
            }
        }

        public string CommandLineArguments
        {
            get
            {
                return _dte.CommandLineArguments;
            }
        }

        public bool get_IsOpenFile(string ViewKind, string FileName)
        {
            return _dte.get_IsOpenFile(ViewKind, FileName);
        }

        public DTE DTE
        {
            get
            {
                return _dte.DTE;
            }
        }

        public int LocaleID
        {
            get
            {
                return _dte.LocaleID;
            }
        }

        public WindowConfigurations WindowConfigurations
        {
            get
            {
                return _dte.WindowConfigurations;
            }
        }

        public Documents Documents
        {
            get
            {
                return _dte.Documents;
            }
        }

        public Document ActiveDocument
        {
            get
            {
                return _dte.ActiveDocument;
            }
        }

        public Globals Globals
        {
            get
            {
                return _dte.Globals;
            }
        }

        public StatusBar StatusBar
        {
            get
            {
                return _dte.StatusBar;
            }
        }

        public string FullName
        {
            get
            {
                return _dte.FullName;
            }
        }

        public bool UserControl
        {
            get
            {
                return _dte.UserControl;
            }

            set
            {
                _dte.UserControl = value;
            }
        }

        public ObjectExtenders ObjectExtenders
        {
            get
            {
                return _dte.ObjectExtenders;
            }
        }

        public Find Find
        {
            get
            {
                return _dte.Find;
            }
        }

        public vsIDEMode Mode
        {
            get
            {
                return _dte.Mode;
            }
        }

        public ItemOperations ItemOperations
        {
            get
            {
                return _dte.ItemOperations;
            }
        }

        public UndoContext UndoContext
        {
            get
            {
                return _dte.UndoContext;
            }
        }

        public Macros Macros
        {
            get
            {
                return _dte.Macros;
            }
        }

        public object ActiveSolutionProjects
        {
            get
            {
                return _dte.ActiveSolutionProjects;
            }
        }

        public DTE MacrosIDE
        {
            get
            {
                return _dte.MacrosIDE;
            }
        }

        public string RegistryRoot
        {
            get
            {
                return _dte.RegistryRoot;
            }
        }

        public DTE Application
        {
            get
            {
                return _dte.Application;
            }
        }

        public ContextAttributes ContextAttributes
        {
            get
            {
                return _dte.ContextAttributes;
            }
        }

        public SourceControl SourceControl
        {
            get
            {
                return _dte.SourceControl;
            }
        }

        public bool SuppressUI
        {
            get
            {
                return _dte.SuppressUI;
            }

            set
            {
                _dte.SuppressUI = value;
            }
        }

        public EnvDTE.Debugger Debugger
        {
            get
            {
                return _dte.Debugger;
            }
        }

        public string Edition
        {
            get
            {
                return _dte.Edition;
            }
        }

        public ToolWindows ToolWindows
        {
            get
            {
                return _dte.ToolWindows;
            }
        }
    }
}
