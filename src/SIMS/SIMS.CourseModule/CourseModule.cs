using Prism.Ioc;
using Prism.Modularity;
using SIMS.CourseModule.ViewModels;
using SIMS.CourseModule.Views;
using System;

namespace SIMS.CourseModule
{
    public class CourseModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Course, CourseViewModel>(nameof(Course));
            containerRegistry.RegisterDialog<AddEditCourse, AddEditCourseViewModel>("addEditCourse");
        }
    }
}
