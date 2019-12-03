using System;
using System.Globalization;
using Xamarin.Forms;

namespace DemoCollectionView.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string code = value.ToString();
            code=code.ToLower();
            var path = "https://flagpedia.net/data/flags/w580/" + code.ToString() + ".png";
            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
