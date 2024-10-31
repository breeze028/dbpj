using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SIMS.Entity;
using SIMS.SysManagementModule.Models;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS.SysManagementModule.ViewModels
{
    public class AddEditRoleViewModel : BindableBase,IDialogAware
    {
        #region 属性和构造函数

        private bool isAddEdit;

        public bool IsAddEdit
        {
            get { return isAddEdit; }
            set { SetProperty(ref isAddEdit, value); }
        }

        private bool isEditMenu;

        public bool IsEditMenu
        {
            get { return isEditMenu; }
            set { SetProperty(ref isEditMenu, value); }
        }

        /// <summary>
        /// 当前实体
        /// </summary>
        private RoleEntity role;

        public RoleEntity Role
        {
            get { return role; }
            set { SetProperty(ref role, value); }
        }

        private List<MenuInfo> menus;

        public List<MenuInfo> Menus
        {
            get { return menus; }
            set { SetProperty(ref menus, value); }
        }

        public AddEditRoleViewModel()
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
            InitInfo();
        }

        private void InitInfo()
        {
            Menus = new List<MenuInfo>();
            var pagedRequst = MenuHttpUtil.GetMenus(null, 1, -1);
            var entities = pagedRequst.items;
            Menus.AddRange(entities.Select(r => new MenuInfo(r)));
            //加载用户已有的角色
            if (Role != null && Role.Id > 0)
            {
                var roleMenus = RoleHttpUtil.GetRoleMenus(Role.Id);
                foreach (var entity in roleMenus.items)
                {
                    var r = this.Menus.FirstOrDefault(r => r.Id == entity.MenuId);
                    if (r != null)
                    {
                        r.IsChecked = true;
                    }
                }
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
            if (Role != null)
            {
                bool flag = false;
                if (Role.Id > 0)
                {
                    flag = RoleHttpUtil.UpdateRole(Role);
                }
                else
                {
                    flag = RoleHttpUtil.AddRole(Role);
                }
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
        }

        private DelegateCommand doCommand;

        public DelegateCommand DoCommand
        {
            get
            {
                if (doCommand == null)
                {
                    doCommand = new DelegateCommand(Do);
                }
                return doCommand;
            }
        }

        private void Do()
        {
            if (Role.Id < 1)
            {
                MessageBox.Show("用户尚未保存，不可以授权");
                return;
            }
            var roleMenus = this.Menus.Where(r => r.IsChecked == true).ToList();
            if (roleMenus != null && roleMenus.Count() > 0)
            {
                var Ids = roleMenus.Select(r => r.Id);
                var strIds = string.Join(",", Ids);
                bool flag = RoleHttpUtil.SetRoleMenus(Role.Id, strIds);
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
            else
            {
                MessageBox.Show("必须至少分配一个菜单");
            }
        }


        #endregion

        #region 函数

        #endregion

        #region 窗口对话框

        public string Title => "新增或编辑角色窗口";

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
            if (parameters != null && parameters.ContainsKey("state"))
            {
                int state = parameters.GetValue<int>("state");
                if (state < 2)
                {
                    this.IsAddEdit = true;
                    this.IsEditMenu = false;
                }
                else
                {
                    this.IsAddEdit = false;
                    this.IsEditMenu = true;
                }
            }
            else
            {
                this.IsAddEdit = true;
                this.IsEditMenu = false;
            }

            if (parameters != null && parameters.ContainsKey("role"))
            {
                this.Role = parameters.GetValue<RoleEntity>("role");
            }
            else
            {
                this.Role = new RoleEntity();
            }
        }

        #endregion
    }
}
