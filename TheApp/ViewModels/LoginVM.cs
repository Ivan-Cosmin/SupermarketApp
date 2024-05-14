using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheApp.Models.BusinessLogicLayer;
using TheApp.Models.EntityLayer;
using TheApp.ViewModels.Commands;

namespace TheApp.ViewModels
{
    internal class LoginVM : INotifyPropertyChanged
    {
        public LoginVM() 
        { 
            TypeUsers = new ObservableCollection<string>
            {
                "Admin",
                "Cashier"
            };
        }

        LoginBLL loginBLL = new LoginBLL();

        private ObservableCollection<string> _typeUsers;
        public ObservableCollection<string> TypeUsers
        {
            get { return _typeUsers; }
            set
            {
                _typeUsers = value;
                OnPropertyChanged();
            }
        }

        private ICommand loginCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<User>(loginBLL.ValidateLogin);
                }
                return loginCommand;
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
