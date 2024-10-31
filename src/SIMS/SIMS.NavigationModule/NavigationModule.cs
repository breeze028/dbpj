using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SIMS.NavigationModule.Views;
using System;

namespace SIMS.NavigationModule
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("NavRegion",typeof(Navigation));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
