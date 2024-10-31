using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SIMS.Entity;
using SIMS.StudentModule.Models;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.StudentModule.ViewModels
{
    public class AddEditStudentViewModel : BindableBase, IDialogAware
    {

        /// <summary>
        /// 班级实体
        /// </summary>
        private ClassesEntity classes;

        public ClassesEntity Classes
        {
            get { return classes; }
            set { SetProperty(ref classes, value); }
        }

        /// <summary>
        /// 班级列表
        /// </summary>
        private List<ClassesEntity> classess;

        public List<ClassesEntity> Classess
        {
            get { return classess; }
            set { SetProperty(ref classess, value); }
        }

        private StudentInfo student;

        public StudentInfo Student
        {
            get { return student; }
            set { student = value; }
        }

        public AddEditStudentViewModel() { 
        
        }

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
            this.Classess = new List<ClassesEntity>();
            var pagedRequst = ClassesHttpUtil.GetClassess(null,null,1,0);//0表示所有班级
            var entities = pagedRequst.items;
            Classess.AddRange(entities);
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
            if (Student != null)
            {
                Student.CreateTime = DateTime.Now;
                Student.LastEditTime = DateTime.Now;
                bool flag = false;
                if (Classes != null) { 
                    Student.ClassesId = Classes.Id;
                }
                if (Student.Id > 0)
                {
                    flag = StudentHttpUtil.UpdateStudent(Student);
                }
                else
                {
                    flag = StudentHttpUtil.AddStudent(Student);
                }
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
        }

        #endregion


        #region IDialogAware 窗口

        public string Title =>  "新增或编辑学生信息";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        /// <summary>
        /// 打开窗口，可传递参数
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                var student = parameters.GetValue<StudentInfo>("student");
                this.Student = student;
            }
            else { 
                this.Student= new StudentInfo();
            }
        }

        #endregion
    }
}
