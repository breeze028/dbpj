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
    public class AddEditUserViewModel : BindableBase,IDialogAware
    {
        #region 属性和构造函数

        private bool isAddEdit;

        public bool IsAddEdit
        {
            get { return isAddEdit; }
            set { SetProperty(ref isAddEdit , value); }
        }

        private bool isEditRole;

        public bool IsEditRole
        {
            get { return isEditRole; }
            set { SetProperty(ref isEditRole , value); }
        }



        /// <summary>
        /// 当前实体
        /// </summary>
        private UserEntity user;

        public UserEntity User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

        private List<RoleInfo> roles;

        public List<RoleInfo> Roles
        {
            get { return roles; }
            set { SetProperty(ref roles , value); }
        }



        public AddEditUserViewModel()
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
            Roles = new List<RoleInfo>();
            var pagedRequst = RoleHttpUtil.GetRoles(null, 1, -1);
            var entities = pagedRequst.items;
            Roles.AddRange(entities.Select(r=>new RoleInfo(r)));
            //加载用户已有的角色
            if (User != null && User.Id > 0) { 
                var userRoles = UserHttpUtil.GetUserRoles(User.Id);
                foreach (var entity in userRoles.items)
                {
                    var r = this.Roles.FirstOrDefault(r => r.Id == entity.RoleId);
                    if (r != null) { 
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
            if (User != null)
            {
                bool flag = false;
                if (User.Id > 0)
                {
                    flag = UserHttpUtil.UpdateUser(User);
                }
                else
                {
                    flag = UserHttpUtil.AddUser(User);
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
            if (User.Id < 1) {
                MessageBox.Show("用户尚未保存，不可以授权");
                return;
            }
            var userRoles = this.Roles.Where(r=>r.IsChecked==true).ToList();
            if (userRoles != null && userRoles.Count() > 0)
            {
                var Ids = userRoles.Select(r => r.Id);
                var strIds = string.Join(",", Ids);
                bool flag = UserHttpUtil.SetUserRoles(User.Id, strIds);
                if (flag) {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
            else {
                MessageBox.Show("必须至少授权一个角色");
            }
        }

        #endregion

        #region 函数

        #endregion

        #region 窗口对话框

        public string Title => "新增或编辑用户窗口";

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
                    this.isEditRole = false;
                }
                else
                {
                    this.IsAddEdit = false;
                    this.isEditRole = true;
                }
            }
            else {
                this.IsAddEdit = true;
                this.isEditRole = false;
            }

            if (parameters != null && parameters.ContainsKey("user"))
            {
                this.User = parameters.GetValue<UserEntity>("user");
            }
            else
            {
                this.User = new UserEntity();
            }
        }

        #endregion
    }
}
