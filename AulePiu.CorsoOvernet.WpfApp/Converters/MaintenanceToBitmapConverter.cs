using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AulePiu.CorsoOvernet.WpfApp.Converters
{
    public class MaintenanceToBitmapConverter : IValueConverter
    {
        static ImageSource iconOff;
        static ImageSource iconOn;

        static MaintenanceToBitmapConverter()
        {
            iconOff = new BitmapImage(new Uri("/Images/icon_off.png",
                UriKind.Relative));

            iconOn = new BitmapImage(new Uri("/Images/icon_on.png",
                UriKind.Relative));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool v = (bool)value;

            if (v)
            {
                return iconOn;
            }
            else
            {
                return iconOff;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}