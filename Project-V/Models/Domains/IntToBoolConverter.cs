using System.Globalization;

namespace Project_V.Models.Domains
{
    //绑定值转换器
    public class IntToBoolConverter : IValueConverter
    {
        //将1/0转为true/false
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*
                - 首先，将value强制转换为整型(int)值。
                - 然后，将转换后的整型值与0进行比较，如果不等于0，则将其转换为true，否则转换为false。
                - 最后，将结果返回。
             */
            return (int)value != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*
               - 首先，将value强制转换为布尔类型(bool)值。
               - 然后，使用条件运算符将布尔值转换为整型值。如果value为true，返回1；如果value为false，返回0。
               - 最后，将结果返回
             */
            return (bool)value ? 1 : 0;     //value有值返回1（被转换为true） 没有值返回0(被转换为false)
        }
    }
}