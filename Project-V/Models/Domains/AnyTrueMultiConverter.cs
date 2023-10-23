using System.Globalization;

namespace Project_V.Models.Domains
{
    //这段代码是一个多值绑定转换器。在WPF或Xamarin等界面框架中，可以使用绑定机制将多个数据源的值绑定到某个目标属性上。但是有时候需要将多个数据源的值转换为单个布尔值，这时可以使用这个转换器。
    public class AnyTrueMultiConverter : IMultiValueConverter
    {
        //这个方法用于将多个值转换为布尔值。接受四个参数：values（多个值数组）、targetType（目标类型，此处应为布尔类型）、parameter（可选参数）、culture（区域性，用于特定语言环境下的数据转换）。
        //在方法体中，首先检查了一些异常情况，比如 values 为 null 或者 targetType 不是布尔类型，直接返回 false 或 UnsetValue（使用 FallbackValue）。然后遍历 values 数组，如果其中有任意一个值不是布尔类型
        //，则返回 false 或 UnsetValue，否则如果其中有任意一个值为 true，则返回 true。如果数组遍历结束后都没有返回，则最后返回 false。

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || !targetType.IsAssignableFrom(typeof(bool)))
            {
                return false;
                // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue               
            }

            foreach (var value in values)
            {
                if (!(value is bool b))
                {
                    return false;
                    // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue
                }
                else if (b)
                {
                    return true;
                }
            }
            return false;
        }
        //这个方法用于将布尔值转换回多个值。接受四个参数：value（布尔值）、targetTypes（目标类型数组，每个目标类型都应为布尔类型）、parameter（可选参数）、culture（区域性）。
        //在方法体中，先检查了 value 是否为布尔类型以及 targetTypes 中是否有非布尔类型的情况，如果有则说明转换回多个值不可行，
        //返回 null。然后判断 value 的值，如果为 false，则遍历 targetTypes，并将每个目标类型都转换为 false 并组成一个对象数组返回。如果 value 为 true，由于无法确定应该将多个目标类型转换为什么值，所以返回 null。
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (!(value is bool b) || targetTypes.Any(t => !t.IsAssignableFrom(typeof(bool))))
            {
                // Return null to indicate conversion back is not possible
                return null;
            }

            if (!b)
            {
                return targetTypes.Select(t => (object)false).ToArray();
            }
            else
            {
                // Can't convert back from true because of ambiguity
                return null;
            }
        }
    }
}
