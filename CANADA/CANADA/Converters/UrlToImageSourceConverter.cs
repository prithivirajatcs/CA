using System;
using System.Globalization;
using Xamarin.Forms;

namespace CANADA.Converters
{
    public class UrlToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Uri uri = new Uri(value.ToString());

                ImageSource imgSource = new UriImageSource { Uri = uri };

                return imgSource;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
