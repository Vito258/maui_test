using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_V.Models.Domains
{

    //这段代码是一个实现了IMultiValueConverter接口的类，用于将多个值转换为一个布尔值的转换器。
    public class AllTrueMultiConverter : IMultiValueConverter
    {
        //在Convert方法中，首先判断传入的values参数是否为空或者目标类型是否是bool类型，如果不是则直接返回false。
        //接着使用foreach循环遍历values数组中的每个值，如果值不是bool类型，则直接返回false。如果值是bool类型，但是为false，则直接返回false。如果所有的值都是bool类型且为true，则返回true。
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
                else if (!b)
                {
                    return false;
                }
            }
            return true;
        }

        //在ConvertBack方法中，首先判断传入的value参数是否是bool类型，以及目标类型数组中是否有任何一个类型不是bool类型，如果不是，则返回null表示无法进行转换回去。
        //如果value为true，则以目标类型数组的长度为准，返回一个全是true的object数组。如果value为false，则无法确定应该将其转换为哪个目标类型，因此返回null表示无法进行转换回去。
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (!(value is bool b) || targetTypes.Any(t => !t.IsAssignableFrom(typeof(bool))))
            {
                // Return null to indicate conversion back is not possible
                return null;
            }

            if (b)
            {
                return targetTypes.Select(t => (object)true).ToArray();
            }
            else
            {
                // Can't convert back from false because of ambiguity
                return null;
            }
        }
    }
}
