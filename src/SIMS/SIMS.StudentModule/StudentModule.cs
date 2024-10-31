using Prism.Ioc;
using Prism.Modularity;
using SIMS.StudentModule.ViewModels;
using SIMS.StudentModule.Views;
using System;

namespace SIMS.StudentModule
{
    public class StudentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Student, StudentViewModel>(nameof(Student));
            containerRegistry.RegisterDialog<AddEditStudent, AddEditStudentViewModel>("addEditStudent");
        }
    }
}
