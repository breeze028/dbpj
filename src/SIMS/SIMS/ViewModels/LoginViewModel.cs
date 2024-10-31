using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SIMS.Utils.Http;
using SIMS.Utils.Personal;
using SIMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private IRegionManager _regionManager;
        private IContainerExtension _container;

        private string userName;

        public string UserName
        {
            get { return userName; }
            set {SetProperty(ref userName , value); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref  password , value); }
        }


        public LoginViewModel(IContainerExtension container,IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        private void InitInfo() {
            var footer = _container.Resolve<Footer>();
            IRegion footerRegion = _regionManager.Regions["LoginFooterRegion"];
            footerRegion.Add(footer);
        }

        #region 命令

        private DelegateCommand loadedCommand;

        public DelegateCommand LoadedCommand
        {
            get
            {
                if (loadedCommand == null)
                {
                    loadedCommand = new DelegateCommand(Loaded);
                }
                return loadedCommand;
            }
        }

        private void Loaded()
        {
            //InitInfo();
        }

        private DelegateCommand loginCommand;

        public DelegateCommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new DelegateCommand(Login);
                }
                return loginCommand;
            }
        }

        private void Login() {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password)) {
                MessageBox.Show("用户名或密码为空，请确认");
                return;
            }
            int Id= LoginHttpUtil.Login(UserName, Password);
            if (Id > 0) { 
                UserInfo.Instance.Id = Id;
                UserInfo.Instance.UserName = UserName;
                //
                var entity  = UserHttpUtil.GetUser(Id);
                if (entity != null)
                {
                    UserInfo.Instance.NickName = entity.NickName;
                }
                CloseWindow();
            }
            else {
                MessageBox.Show("用户名密码不正确，请确认");
                return;
            }
        }

        private DelegateCommand cancelCommand;

        public DelegateCommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new DelegateCommand(Cancel);
                }
                return cancelCommand;
            }
        }

        private void Cancel() {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        #endregion

        #region DialogAware接口

        public string Title => "SIMS-Login";

        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 成功时关闭窗口
        /// </summary>
        public void CloseWindow() {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            //当关闭时
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //传递解析参数
        }

        #endregion
    }
}
