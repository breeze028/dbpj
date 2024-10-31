using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SIMS.Utils.Events;
using SIMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {

        private IEventAggregator eventAggregator;
        private IContainerExtension _container;
        private IRegionManager _regionManager;
        private IDialogService _dialogService;
        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator eventAggregator,IDialogService dialogService) { 
            this._container = container;
            this._regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this._dialogService = dialogService;
            //弹出登录窗口
            this._dialogService.ShowDialog("Login", null, LoginCallback, "MetroDialogWindow");
            this.eventAggregator.GetEvent<NavEvent>().Subscribe(Navigation);
        }

        private void LoginCallback(IDialogResult dialogResult) {
            if (dialogResult.Result != ButtonResult.OK) {
                Application.Current.Shutdown();
            }
        }

        #region 事件和命令

        private DelegateCommand loadedCommand;

        public DelegateCommand LoadedCommand
        {
            get {
                if (loadedCommand == null) {
                    loadedCommand = new DelegateCommand(Loaded);
                }
                return loadedCommand; }
        }

        private void Loaded() {
            InitInfo();
        }


        

        private void InitInfo() {
            var header = _container.Resolve<Header>();
            IRegion headerRegion = _regionManager.Regions["HeaderRegion"];
            headerRegion.Add(header);
            //
            var footer = _container.Resolve<Footer>();
            IRegion footerRegion = _regionManager.Regions["FooterRegion"];
            footerRegion.Add(footer);

            var welcome = _container.Resolve<Welcome>();
            IRegion welcomeRegion = _regionManager.Regions["ContentRegion"];
            welcomeRegion.Add(welcome);
        }

        private void Navigation(string source) {
            _regionManager.RequestNavigate("ContentRegion", source);
            //MessageBox.Show(source);
        }

        #endregion
    }
}
