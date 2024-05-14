using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheApp.Models.DataAccessLayer;
using TheApp.Models.EntityLayer;
using TheApp.Views;

namespace TheApp.Models.BusinessLogicLayer
{
    internal class LoginBLL
    {
        LoginDAL loginDAL = new LoginDAL();
        public void ValidateLogin(User user)
        {
            if(loginDAL.ValidateLogin(user) == "Admin")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if(loginDAL.ValidateLogin(user) == "Cashier")
            {
                CashierWindow cashierWindow = new CashierWindow();
                cashierWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

    }
}
