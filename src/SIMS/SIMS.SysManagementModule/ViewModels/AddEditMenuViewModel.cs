using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SIMS.Entity;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SysManagementModule.ViewModels
{
    public class AddEditMenuViewModel:BindableBase,IDialogAware
    {
        #region 属性和构造函数

        /// <summary>
        /// 当前实体
        /// </summary>
        private MenuEntity menu;

        public MenuEntity Menu
        {
            get { return menu; }
            set { SetProperty(ref menu, value); }
        }

        public AddEditMenuViewModel()
        {

        }


        #endregion

        #region Command

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

        private void Cancel()
        {
            RequestClose?.Invoke((new DialogResult(ButtonResult.Cancel)));
        }

        private DelegateCommand saveCommand;

        public DelegateCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(Save);
                }
                return saveCommand;
            }
        }

        private void Save()
        {
            if (Menu != null)
            {
                bool flag = false;
                if (Menu.Id > 0)
                {
                    flag = MenuHttpUtil.UpdateMenu(Menu);
                }
                else
                {
                    flag = MenuHttpUtil.AddMenu(Menu);
                }
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
        }


        #endregion

        #region 函数

        #endregion

        #region 窗口对话框

        public string Title => "新增或编辑菜单窗口";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("menu"))
            {
                this.Menu = parameters.GetValue<MenuEntity>("menu");
            }
            else
            {
                this.Menu = new MenuEntity();
            }
        }

        #endregion
    }
}
