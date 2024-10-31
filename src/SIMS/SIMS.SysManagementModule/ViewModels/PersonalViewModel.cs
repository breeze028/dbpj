using Prism.Commands;
using Prism.Mvvm;
using SIMS.Utils.Personal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SysManagementModule.ViewModels
{
    public class PersonalViewModel : BindableBase
    {
        private UserInfo userInfo;

        public UserInfo UserInfo { get { return userInfo; } set { SetProperty(ref userInfo , value); } }


        public PersonalViewModel() { 
        
        }

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

        private void InitInfo()
        {
            this.UserInfo = UserInfo.Instance;
        }

        #endregion
    }
}
