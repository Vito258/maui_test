using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//创建附加属性
//创建附加属性的过程如下：

//BindableProperty使用方法重载之CreateAttached一创建实例。
//提供 staticGetPropertyName 和 SetPropertyName 方法作为附加属性的访问器。
namespace Project_V.Controls
{
    public class Shadow
    {
        //创建附加属性
        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(Shadow), false);

        //创建访问器
        public static bool GetHasShadow(BindableObject view)
        {
            return (bool)view.GetValue(HasShadowProperty);  //传入要获取值的可绑定属性标识符，然后将生成的值强制转换为所需的类型。
        }

        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);    //传入要设置值的可绑定属性标识符和要设置的值。
        }
    }
}
