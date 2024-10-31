﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SIMS.Entity;
using SIMS.StudentModule.Models;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS.StudentModule.ViewModels
{
    public class StudentViewModel:BindableBase
    {
        #region 属性及构造函数

        /// <summary>
        /// 学号
        /// </summary>
        private string no;

        public string No
        {
            get { return no; }
            set { SetProperty(ref no , value); }
        }

        /// <summary>
        /// 学生姓名
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private ObservableCollection<StudentInfo> students;

        public ObservableCollection<StudentInfo> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        private IDialogService dialogService;

        public StudentViewModel(IDialogService dialogService) {
            this.dialogService = dialogService;
            this.pageNum = 1;
            this.pageSize = 20;
        }

        private void InitInfo() {
            Students = new ObservableCollection<StudentInfo>();
            var pagedRequst = StudentHttpUtil.GetStudents(this.No,this.Name, this.pageNum, this.pageSize);
            var entities = pagedRequst.items;
            Students.AddRange(entities.Select(r=>new StudentInfo(r)));
            //
            this.TotalCount = pagedRequst.count;
            this.TotalPage=((int)Math.Ceiling(this.TotalCount*1.0/this.pageSize));
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
            this.dialogService.ShowDialog("addEditStudent", null, AddEditCallBack, "MetroDialogWindow");
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

        private void Edit(object obj) {
            if (obj == null)
            {
                return;
            }
            var Id = int.Parse(obj.ToString());
            var student = this.Students.FirstOrDefault(r => r.Id == Id);
            if (student == null)
            {
                MessageBox.Show("无效的学生ID");
                return;
            }
            
            IDialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("student", student);
            this.dialogService.ShowDialog("addEditStudent", dialogParameters, AddEditCallBack, "MetroDialogWindow");
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
            var classes = this.Students.FirstOrDefault(r => r.Id == Id);
            if (classes == null)
            {
                MessageBox.Show("无效的学生ID");
                return;
            }
            if (MessageBoxResult.Yes != MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButton.YesNo))
            {
                return;
            }
            bool flag = StudentHttpUtil.DeleteStudent(Id);
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
            set { SetProperty(ref pageNum , value); }
        }

        /// <summary>
        /// 每页显示多少条记录
        /// </summary>
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { SetProperty(ref pageSize , value); }
        }

        /// <summary>
        ///总条数
        /// </summary>
        private int totalCount;

        public int TotalCount
        {
            get { return totalCount; }
            set { SetProperty(ref totalCount , value); }
        }

        /// <summary>
        ///总页数
        /// </summary>
        private int totalPage;

        public int TotalPage
        {
            get { return totalPage; }
            set { SetProperty(ref totalPage , value); }
        }


        /// <summary>
        /// 跳转页
        /// </summary>
        private int jumpNum;

        public int JumpNum
        {
            get { return jumpNum; }
            set { SetProperty(ref jumpNum , value); }
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
            MessageBox.Show("第一页");
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

        private void JumpPage() { 
            
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

        private void PrevPage() { 
        
        }

        /// <summary>
        /// 下一页命令
        /// </summary>
        private DelegateCommand nextPageCommand;

        public DelegateCommand NextPageCommand
        {
            get {
                if (nextPageCommand == null) {
                    nextPageCommand = new DelegateCommand(NextPage);
                }
                return nextPageCommand; }
        }

        private void NextPage()
        {
        }


        #endregion

        #region 方法


        #endregion
    }
}