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

namespace SIMS.ScoreModule.ViewModels
{
    public class AddEditScoreViewModel : BindableBase, IDialogAware
    {

        #region 属性和构造函数

        /// <summary>
        /// 当前实体
        /// </summary>
        private ScoreEntity score;

        public ScoreEntity Score
        {
            get { return score; }
            set { SetProperty(ref score , value); }
        }


        /// <summary>
        /// 下拉框选择的学生
        /// </summary>
        private StudentEntity student;

        public StudentEntity Student
        {
            get { return student; }
            set { SetProperty(ref student , value); }
        }

        /// <summary>
        /// 学生列表
        /// </summary>
        private List<StudentEntity> students;

        public List<StudentEntity> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        private CourseEntity course;

        public CourseEntity Course
        {
            get { return course; }
            set {SetProperty(ref course , value); }
        }


        /// <summary>
        /// 课程列表
        /// </summary>
        private List<CourseEntity> courses;

        public List<CourseEntity> Courses
        {
            get { return courses; }
            set { SetProperty(ref courses, value); }
        }

        public AddEditScoreViewModel() { 
        
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
            LoadStudents();
            LoadCourses();

            //如果有班长，则为班长赋值
            if (Score.StudentId > 0)
            {
                this.Student = this.Students?.FirstOrDefault(r => r.Id == Score.StudentId);
            }
            if (Score.CourseId > 0) { 
                this.Course = this.Courses?.FirstOrDefault(r=>r.Id == Score.CourseId);
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
            if (Score != null)
            {
                Score.CreateTime = DateTime.Now;
                Score.LastEditTime = DateTime.Now;
                if (Student != null)
                {
                    Score.StudentId = Student.Id;
                }
                if (Course != null) { 
                    Score.CourseId = Course.Id;
                }
                bool flag = false;
                if (Score.Id > 0)
                {
                    flag = ScoreHttpUtil.UpdateScore(Score);
                }
                else
                {
                    flag = ScoreHttpUtil.AddScore(Score);
                }
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
        }


        #endregion

        #region 函数

        /// <summary>
        /// 加载学生列表
        /// </summary>
        private void LoadStudents() {
            this.Students = new List<StudentEntity>();
            var pagedRequst = StudentHttpUtil.GetStudents(null, null, 1, -1);
            var entities = pagedRequst.items;
            Students.AddRange(entities);
        }

        /// <summary>
        /// 加载课程列表
        /// </summary>
        private void LoadCourses() {
            this.Courses = new List<CourseEntity>();
            var pagedRequst = CourseHttpUtil.GetCourses(null, null, 1, -1);
            var entities = pagedRequst.items;
            Courses.AddRange(entities);
        }

        #endregion

        #region 窗口对话框

        public string Title => "新增或编辑成绩窗口";

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
            if (parameters != null && parameters.ContainsKey("score"))
            {
                this.Score = parameters.GetValue<ScoreEntity>("score");
            }
            else
            {
                this.Score = new ScoreEntity();
            }
        }

        #endregion
    }
}
