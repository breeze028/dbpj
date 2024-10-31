using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SIMS.SysManagementModule.ViewModels;
using SIMS.SysManagementModule.Views;
using System;

namespace SIMS.SysManagementModule
{
    public class SysManagementModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(User));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<User, UserViewModel>(nameof(User));
            containerRegistry.RegisterForNavigation<Role, RoleViewModel>(nameof(Role));
            containerRegistry.RegisterForNavigation<Personal, PersonalViewModel>(nameof(Personal));
            containerRegistry.RegisterForNavigation<Menu, MenuViewModel>(nameof(Menu));

            containerRegistry.RegisterDialog<AddEditUser, AddEditUserViewModel>("addEditUser");
            containerRegistry.RegisterDialog<AddEditMenu, AddEditMenuViewModel>("addEditMenu");
            containerRegistry.RegisterDialog<AddEditRole, AddEditRoleViewModel>("addEditRole");
        }
    }
}
