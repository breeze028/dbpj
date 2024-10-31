using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
using Prism.Unity;
using SIMS.Dialogs;
using SIMS.ViewModels;
using SIMS.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<Login, LoginViewModel>(nameof(Login));
            containerRegistry.Register<IDialogWindow, MetroDialogWindow>("MetroDialogWindow");
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
