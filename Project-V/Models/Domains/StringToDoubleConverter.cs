using System.Globalization;

namespace Project_V.Models.Domains
{
    //实现Convert()方法，实现值的转换
    //实现ConvertBack()方法，反转值
    public class StringToDoubleConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return Double.Parse((string)value);
            return Double.Parse(value.ToString());
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
