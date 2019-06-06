// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGeneratorParameters.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Windows;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public interface IInfrastructure<TViewModel, TView>
        where TViewModel : ObservableObject
        where TView : Window
    {
        TViewModel ViewModel { get; }

        TView View { get; }
    }
}