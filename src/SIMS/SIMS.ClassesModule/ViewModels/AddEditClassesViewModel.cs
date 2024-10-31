using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SIMS.ClassesModule.Models;
using SIMS.Entity;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ClassesModule.ViewModels
{
    public class AddEditClassesViewModel : BindableBase, IDialogAware
    {
        #region 属性和构造函数

        /// <summary>
        /// 班级实体
        /// </summary>
        private ClassesInfo classes;
    
        public ClassesInfo Classes
        {
            get { return classes; }
            set { SetProperty(ref classes ,value); }
        }

        private List<StudentEntity> monitors;

        public List<StudentEntity> Monitors
        {
            get { return monitors; }
            set { SetProperty(ref monitors , value); }
        }

        private StudentEntity monitor;

        public StudentEntity Monitor
        {
            get { return monitor; }
            set { SetProperty(ref monitor, value); }
        }

        public AddEditClassesViewModel() { 
        
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
            this.Monitors= new List<StudentEntity>();
            if (Classes?.Id>0) { 
                var pagedRequst = StudentHttpUtil.GetStudentsByClasses(Classes.Id);
                var entities = pagedRequst.items;
                Monitors.AddRange(entities);
                //如果有班长，则为班长赋值
                if (Classes.Monitor > 0) { 
                    this.Monitor= this.Monitors?.FirstOrDefault(r=>r.Id==Classes.Monitor);
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

        private DelegateCommand  saveCommand;

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

        private void Save() {
            if (Classes != null) {
                Classes.CreateTime = DateTime.Now;
                Classes.LastEditTime = DateTime.Now;
                if (Monitor != null)
                {
                    Classes.Monitor = Monitor.Id;
                }
                else { 
                    Classes.Monitor= null;
                }
                bool flag=false;
                if (Classes.Id > 0) {
                   flag = ClassesHttpUtil.UpdateClasses(Classes);
                }
                else { 
                   flag = ClassesHttpUtil.AddClasses(Classes);
                }
                if (flag)
                {
                    RequestClose?.Invoke((new DialogResult(ButtonResult.OK)));
                }
            }
        }


        #endregion

        #region 对话框

        public string Title =>  "新增或编辑班级信息";

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
            if (parameters != null && parameters.ContainsKey("classes"))
            {
                this.Classes = parameters.GetValue<ClassesInfo>("classes");
            }
            else { 
                this.Classes = new ClassesInfo();
            }
        }

        #endregion

    }
}
