using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TheApp.Models.EntityLayer;

namespace TheApp.Converters
{
    internal class UserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                return new User()
                {
                    Username = values[0].ToString(),
                    Password = values[1].ToString(),
                    Type = values[2].ToString()
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Person pers = value as Person;
            //object[] result = new object[2] { pers.Name, pers.Address };
            //return result;
            throw new NotImplementedException();
        }
    }
}

