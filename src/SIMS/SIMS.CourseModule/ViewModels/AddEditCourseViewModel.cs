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

namespace SIMS.CourseModule.ViewModels
{
    public class AddEditCourseViewModel:BindableBase,IDialogAware
    {
        #region 属性和构造函数

        /// <summary>
        /// 班级实体
        /// </summary>
        private CourseEntity course;

        public CourseEntity Course
        {
            get { return course; }
            set { SetProperty(ref course, value); }
        }

        public AddEditCourseViewModel()
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
            if (Course != null)
            {
                Course.CreateTime = DateTime.Now;
                Course.LastEditTime = DateTime.Now;
                
                bool flag = false;
                if (Course.Id > 0)
                {
                    flag = CourseHttpUtil.UpdateCourse(Course);
                }
                else
                {
                    flag = CourseHttpUtil.AddCourse(Course);
                }
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
        }


        #endregion

        #region 对话框

        public string Title => "新增或编辑课程信息";

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
            if (parameters != null && parameters.ContainsKey("course"))
            {
                this.Course = parameters.GetValue<CourseEntity>("course");
            }
            else
            {
                this.Course = new CourseEntity();
            }
        }

        #endregion

    }
}
