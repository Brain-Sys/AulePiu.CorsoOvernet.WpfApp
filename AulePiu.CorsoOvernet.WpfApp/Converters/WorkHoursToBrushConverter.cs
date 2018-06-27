using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AulePiu.CorsoOvernet.WpfApp.Converters
{
    public class WorkHoursToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int h = (int)value;

            if (h == 0)
                return Application.Current.Resources["NewMachine"];
            else if (h > 0 && h < 500)
                return Application.Current.Resources["Low"];
            else if (h >= 500 && h < 5000)
                return Application.Current.Resources["Medium"];
            else
                return Application.Current.Resources["High"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}