using JetBrains.Annotations;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.NavigationModule.Views
{
    /// <summary>
    /// Navigation.xaml 的交互逻辑
    /// </summary>
    public partial class Navigation : UserControl
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            var menuItem = e.InvokedItem as HamburgerMenuItem;
            if (menuItem != null) { 
                var tag = menuItem.Tag as string;
                var label = menuItem.Label as string;
                if (!string.IsNullOrEmpty(tag)) { 
                    
                }
            }
        }

        private void HamburgerMenuControl_HamburgerButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.HamburgerMenuControl.IsPaneOpen)
            {
                // close the menu if a item was selected
                this.Width = 48;
            }
            else
            {
                this.Width = 200;
            }
        }
    }
}
