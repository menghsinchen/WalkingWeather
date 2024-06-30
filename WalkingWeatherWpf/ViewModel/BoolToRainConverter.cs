using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WalkingWeatherWpf.ViewModel
{
    public class BoolToRainConverter : IValueConverter
    {
        private const string CURRENTLY_RAINING = "Currently raining";
        private const string CURRENTLY_NOT_RAINING = "Currently not raining";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;
            return isRaining ? CURRENTLY_RAINING : CURRENTLY_NOT_RAINING;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isRaining = value.ToString();
            return isRaining == CURRENTLY_RAINING ? true : false;
        }
    }
}
