using System.Globalization;

namespace Project_V.Models.Domains
{
    public class BoolToObjectConverter<T> : IValueConverter
    {
        //绑定值转换器中可以有属性和泛型参数
        public T TrueObject { get; set; }
        public T FalseObject { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueObject : FalseObject;           //从布尔值转化为Object
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((T)value).Equals(TrueObject);                   //从Object转换为布尔值
        }
    }
}