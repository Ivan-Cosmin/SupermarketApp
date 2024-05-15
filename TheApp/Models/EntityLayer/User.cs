﻿namespace TheApp.Models.EntityLayer
{
    internal class User : BasePropertyChanged
    {
        private string _username;
        private string _password;
        private string _type;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string Type
        {             
            get { return _type; }
            set
            {
                _type = value;
                NotifyPropertyChanged("Type");
            }
        }
    }
}
