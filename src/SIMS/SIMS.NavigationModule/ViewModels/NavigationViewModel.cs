using MahApps.Metro.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using SIMS.Entity;
using SIMS.NavigationModule.Models;
using SIMS.NavigationModule.Views;
using SIMS.Utils.Events;
using SIMS.Utils.Http;
using SIMS.Utils.Personal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SIMS.NavigationModule.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        #region 属性和构造函数

        private IEventAggregator eventAggregator;

        private List<HamburgerMenuItemBase> navItems;

        public List<HamburgerMenuItemBase> NavItems { get { return navItems; } set { SetProperty(ref navItems, value); } }

        public NavigationViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            navItems = new List<HamburgerMenuItemBase>();

            var userRight1 = new UserRight() { RoleName = "管理员", Icon = "NULL", Id = 9, ParentId = null, MenuName = "学生管理", SortId = 1, Url = "NULL" };
            var userRight2 = new UserRight() { RoleName = "管理员", Icon = "/images/icon_student.png", Id = 10, ParentId = 9, MenuName = "学生管理", SortId = 1, Url = "Students" };
            var userRight3 = new UserRight() { RoleName = "管理员", Icon = "/images/icon_classes.png", Id = 11, ParentId = 9, MenuName = "班级管理", SortId = 2, Url = "Classes" };

            var userRights = new List<UserRight>();
            userRights.Add(userRight1);
            userRights.Add(userRight2);
            userRights.Add(userRight3);

            //var userRights = RoleHttpUtil.GetUserRights(UserInfo.Instance.Id);
            var parents = userRights.Where(x => x.ParentId == null).OrderBy(r=>r.SortId);
            foreach (var parent in parents) {
                navItems.Add(new HamburgerMenuHeaderItem() { Label = parent.MenuName });
                var subItems = userRights.Where(r=>r.ParentId==parent.Id).OrderBy(r=>r.SortId);
                foreach (var subItem in subItems) {
                    navItems.Add(new HamburgerMenuGlyphItem() { Label = subItem.MenuName, Tag = subItem.Url, Glyph = subItem.Icon });
                }
            }
            UserInfo.Instance.Roles = String.Join(',', userRights.Select(r=>r.RoleName).Distinct().ToList());
        }

        #endregion

        #region 命令

        private DelegateCommand<object> navCommand;

        public DelegateCommand<object> NavCommand
        {
            get
            {
                if (navCommand == null)
                {

                    navCommand = new DelegateCommand<object>(Navigation);
                }
                return navCommand;
            }
        }

        private void Navigation(object obj) {
            var menuItem = (HamburgerMenuItem)obj;
            if (menuItem != null) { 
                var tag = menuItem.Tag;
                if (tag!=null) { 
                    this.eventAggregator.GetEvent<NavEvent>().Publish(tag.ToString());
                }
            }
        }

        #endregion
    }
}
