using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SIMS.ScoreModule.ViewModels;
using SIMS.ScoreModule.Views;
using System;

namespace SIMS.ScoreModule
{
    public class ScoreModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Score,ScoreViewModel>(nameof(Score));
            containerRegistry.RegisterDialog<AddEditScore, AddEditScoreViewModel>("addEditScore");
        }
    }
}
