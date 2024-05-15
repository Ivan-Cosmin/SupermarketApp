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
            if (user.Username == null)
            {
               throw new Exception ("Please enter username");
            }

            if(user.Password == null)
            {
                throw new Exception("Please enter password");
            }

            string userType = loginDAL.ValidateLogin(user);

            if(userType == "Admin")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if(userType == "Cashier")
            {
                CashierWindow cashierWindow = new CashierWindow();
                cashierWindow.Show();
            }
            else
            {
                throw new Exception("Invalid username or password");
            }
        }

    }
}
