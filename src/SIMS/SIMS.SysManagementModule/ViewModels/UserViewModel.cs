using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SIMS.Entity;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS.SysManagementModule.ViewModels
{
    public class UserViewModel:BindableBase
    {
        #region 属性或构造方法

        /// <summary>
        /// 课程名称
        /// </summary>
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        

        private ObservableCollection<UserEntity> users;

        public ObservableCollection<UserEntity> Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }

        private IDialogService dialogService;

        public UserViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            this.pageNum = 1;
            this.pageSize = 20;
        }

        private void InitInfo()
        {
            Users = new ObservableCollection<UserEntity>();
            var pagedRequst = UserHttpUtil.GetUsers(UserName, this.pageNum, this.pageSize);
            var entities = pagedRequst.items;
            Users.AddRange(entities);
            //
            this.TotalCount = pagedRequst.count;
            this.TotalPage = ((int)Math.Ceiling(this.TotalCount * 1.0 / this.pageSize));
        }

        #endregion

        #region 事件

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

        private DelegateCommand queryCommand;

        public DelegateCommand QueryCommand
        {
            get
            {
                if (queryCommand == null)
                {
                    queryCommand = new DelegateCommand(Query);
                }
                return queryCommand;
            }
        }

        private void Query()
        {
            this.pageNum = 1;
            this.InitInfo();
        }

        /// <summary>
        /// 新增命令
        /// </summary>
        private DelegateCommand addCommand;

        public DelegateCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(Add);
                }
                return addCommand;
            }
        }

        private void Add()
        {
            IDialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("state", 0);//新增用户
            this.dialogService.ShowDialog("addEditUser", dialogParameters, AddEditCallBack, "MetroDialogWindow");
        }

        private void AddEditCallBack(IDialogResult dialogResult)
        {
            if (dialogResult != null && dialogResult.Result == ButtonResult.OK)
            {
                //刷新列表
                this.pageNum = 1;
                this.InitInfo();
            }
        }

        private DelegateCommand<object> editUserRoleCommand;

        public DelegateCommand<object> EditUserRoleCommand
        {
            get
            {
                if (editUserRoleCommand == null)
                {
                    editUserRoleCommand = new DelegateCommand<object>(EditUserRole);
                }
                return editUserRoleCommand;
            }
        }

        private void EditUserRole(object obj)
        {
            if (obj == null)
            {
                return;
            }
            var Id = int.Parse(obj.ToString());
            var user = this.Users.FirstOrDefault(r => r.Id == Id);
            if (user == null)
            {
                MessageBox.Show("无效的用户ID");
                return;
            }
            IDialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("user", user);
            dialogParameters.Add("state", 2);//编辑权限
            this.dialogService.ShowDialog("addEditUser", dialogParameters, AddEditCallBack, "MetroDialogWindow");
        }

        /// <summary>
        /// 编辑命令
        /// </summary>
        private DelegateCommand<object> editCommand;

        public DelegateCommand<object> EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new DelegateCommand<object>(Edit);
                }
                return editCommand;
            }
        }

        private void Edit(object obj)
        {
            if (obj == null)
            {
                return;
            }
            var Id = int.Parse(obj.ToString());
            var user = this.Users.FirstOrDefault(r => r.Id == Id);
            if (user == null)
            {
                MessageBox.Show("无效的用户ID");
                return;
            }
            IDialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("user", user);
            dialogParameters.Add("state", 1);//编辑用户
            this.dialogService.ShowDialog("addEditUser", dialogParameters, AddEditCallBack, "MetroDialogWindow");
        }

        /// <summary>
        /// 编辑命令
        /// </summary>
        private DelegateCommand<object> deleteCommand;

        public DelegateCommand<object> DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new DelegateCommand<object>(Delete);
                }
                return deleteCommand;
            }
        }

        private void Delete(object obj)
        {
            if (obj == null)
            {
                return;
            }
            var Id = int.Parse(obj.ToString());
            var user = this.Users.FirstOrDefault(r => r.Id == Id);
            if (user == null)
            {
                MessageBox.Show("无效的用户ID");
                return;
            }
            if (MessageBoxResult.Yes != MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButton.YesNo))
            {
                return;
            }
            bool flag = UserHttpUtil.DeleteUser(Id);
            if (flag)
            {
                this.pageNum = 1;
                this.InitInfo();
            }
        }

        #endregion

        #region 分页

        /// <summary>
        /// 当前页码
        /// </summary>
        private int pageNum;

        public int PageNum
        {
            get { return pageNum; }
            set { SetProperty(ref pageNum, value); }
        }

        /// <summary>
        /// 每页显示多少条记录
        /// </summary>
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { SetProperty(ref pageSize, value); }
        }

        /// <summary>
        ///总条数
        /// </summary>
        private int totalCount;

        public int TotalCount
        {
            get { return totalCount; }
            set { SetProperty(ref totalCount, value); }
        }

        /// <summary>
        ///总页数
        /// </summary>
        private int totalPage;

        public int TotalPage
        {
            get { return totalPage; }
            set { SetProperty(ref totalPage, value); }
        }


        /// <summary>
        /// 跳转页
        /// </summary>
        private int jumpNum;

        public int JumpNum
        {
            get { return jumpNum; }
            set { SetProperty(ref jumpNum, value); }
        }

        /// <summary>
        /// 首页命令
        /// </summary>
        private DelegateCommand firstPageCommand;

        public DelegateCommand FirstPageCommand
        {
            get
            {
                if (firstPageCommand == null)
                {
                    firstPageCommand = new DelegateCommand(FirstPage);
                }
                return firstPageCommand;
            }

        }

        private void FirstPage()
        {
            this.PageNum = 1;
            this.InitInfo();
        }

        /// <summary>
        /// 跳转页命令
        /// </summary>
        private DelegateCommand jumpPageCommand;

        public DelegateCommand JumpPageCommand
        {
            get
            {
                if (jumpPageCommand == null)
                {
                    jumpPageCommand = new DelegateCommand(JumpPage);
                }
                return jumpPageCommand;
            }
        }

        private void JumpPage()
        {
            if (jumpNum < 1)
            {
                MessageBox.Show("请输入跳转页");
                return;
            }
            if (jumpNum > this.totalPage)
            {
                MessageBox.Show($"跳转页面必须在[1,{this.totalPage}]之间，请确认。");
                return;
            }
            this.PageNum = jumpNum;

            this.InitInfo();
        }

        /// <summary>
        /// 前一页
        /// </summary>
        private DelegateCommand prevPageCommand;

        public DelegateCommand PrevPageCommand
        {
            get
            {
                if (prevPageCommand == null)
                {
                    prevPageCommand = new DelegateCommand(PrevPage);
                }
                return prevPageCommand;
            }
        }

        private void PrevPage()
        {
            this.PageNum--;
            if (this.PageNum < 1)
            {
                this.PageNum = 1;
            }
            this.InitInfo();
        }

        /// <summary>
        /// 下一页命令
        /// </summary>
        private DelegateCommand nextPageCommand;

        public DelegateCommand NextPageCommand
        {
            get
            {
                if (nextPageCommand == null)
                {
                    nextPageCommand = new DelegateCommand(NextPage);
                }
                return nextPageCommand;
            }
        }

        private void NextPage()
        {
            this.PageNum++;
            if (this.PageNum > this.TotalPage)
            {
                this.PageNum = this.TotalPage;
            }
            this.InitInfo();
        }

        #endregion
    }
}
