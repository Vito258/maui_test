using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_V.Controls
{

    public class Expander : Grid
    {
        //创建可绑定属性
        //可绑定属性的命名约定是，可绑定属性标识符必须与方法中指定的 Create 属性名称匹配，并在其后面追加“Property”。
        public static readonly BindableProperty TextProperty =
                               BindableProperty.Create("Text", typeof(string), typeof(Label), "这是一条默认值");
        //创建访问器
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }


        //设置许多可选参数来启用高级可绑定属性方案
        //propertyChanged:值更改时调用方法
        //validateValue ：验证回调，指定static方法、向可绑定属性注册验证回调方法。 设置可绑定属性的值时，将调用指定的回调方法。
        //coerceValue: 强制值回调的方法可以使用可绑定属性注册强制值回调方法。 当可绑定属性的值即将更改时，将调用指定的回调方法，以便你可以在应用新值之前对其进行调整。
                     //通过调用其强制值回调来强制重新计算其 BindableProperty 参数的值。
                     //强制值回调用于在属性的值即将更改时强制重新计算可绑定属性。 例如，强制值回调可用于确保一个可绑定属性的值不大于另一个可绑定属性的值。
        public static readonly BindableProperty IsExpandedProperty =
        BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(Expander), false, propertyChanged: OnIsExpandedChanged);

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(TextProperty, value);
        }

        static void OnIsExpandedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Property changed implementation goes here
        }


        public double MaximumAngle
        {
            get => (double)GetValue(MaximumAngleProperty);
            set => SetValue(MaximumAngleProperty, value);
        }
        public static readonly BindableProperty AngleProperty =
            BindableProperty.Create("Angle", typeof(double), typeof(MainPage), 0.0, coerceValue: CoerceAngle);
        public static readonly BindableProperty MaximumAngleProperty =
            BindableProperty.Create("MaximumAngle", typeof(double), typeof(MainPage), 360.0, propertyChanged: ForceCoerceValue);

        static object CoerceAngle(BindableObject bindable, object value)
        {
            Expander e = (Expander)bindable;
            double input = (double)value;

            if (input > e.MaximumAngle)
            {
                input = e.MaximumAngle;
            }

            return input;
        }

        static void ForceCoerceValue(BindableObject bindable, object oldValue, object newValue)
        {
            bindable.CoerceValue(AngleProperty);
        }
        //defaultValueCreator:使用 Func 创建默认值
        public static readonly BindableProperty DateProperty =
           BindableProperty.Create("Date", typeof(DateTime), typeof(Expander), default(DateTime), BindingMode.TwoWay, defaultValueCreator: bindable => DateTime.Today);
    }
}
