using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFFinanceManager.Enums;
using XFFinanceManager.Resources;

namespace XFFinanceManager.Converters
{
    public class WalletCategoryEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = (int)value;

            string result = string.Empty;

            switch (enumVal)
            {
                case 0:
                    result = AppResources.ATM;
                    break;
                case 1:
                    result = AppResources.Cash;
                    break;                
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = (int)value;

            return enumVal;
        }
    }
}