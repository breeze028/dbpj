using Prism.Ioc;
using Prism.Modularity;
using SIMS.ClassesModule.ViewModels;
using SIMS.ClassesModule.Views;
using System;

namespace SIMS.ClassesModule
{
    public class ClassesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Classes, ClassesViewModel>(nameof(Classes));
            containerRegistry.RegisterDialog<AddEditClasses, AddEditClassesViewModel>("addEditClasses");
        }
    }
}
