// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGeneratorParameters.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Windows;

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    public abstract class InfrastructureBase<TViewModel, TView> : IInfrastructure<TViewModel, TView>
        where TViewModel : ObservableObject
        where TView : Window
    {
        public abstract TViewModel ViewModel { get; }
        public abstract TView View { get; }
    }
}