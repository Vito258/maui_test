using System.Globalization;

namespace Project_V.Models.Domains
{
    public class FloatToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Math.Round 四舍五入
            return (int)Math.Round((float)value * GetParameter(parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value / GetParameter(parameter);
        }
        /*
         这段代码定义了一个名为GetParameter的方法，该方法接受一个object类型的参数parameter，并返回一个double类型的值。

         代码首先检查parameter的类型是否为float，如果是，则将其转换为float类型并返回。

         接下来，代码检查parameter的类型是否为int，如果是，则将其转换为int类型并返回。

         然后，代码检查parameter的类型是否为string，如果是，则先将其转换为string类型，然后再使用float.Parse方法将其转换为float类型并返回。

         如果parameter的类型不是以上这些类型，则返回默认值1作为double类型。

         总之，该方法的目的是将parameter参数转换为double类型，并返回相应的值
         */
        double GetParameter(object parameter)
        {
            if (parameter is float)
                return (float)parameter;
            else if (parameter is int)
                return (int)parameter;
            else if (parameter is string)
                return float.Parse((string)parameter);

            return 1;
        }
    }
}
