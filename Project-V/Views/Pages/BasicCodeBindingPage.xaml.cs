namespace Project_V.Views.Pages;

public partial class BasicCodeBindingPage : ContentPage
{
    public BasicCodeBindingPage()
    {
        InitializeComponent();
        //在代码中一样，数据绑定是在目标对象（即 Label）上设置的。 两个 XAML 标记扩展用于定义数据绑定：
        //引用源对象（命名为 slider 的 Slider）需要 x:Reference 标记扩展。
        //Binding 标记扩展将 Label 的 Rotation 属性链接到 Slider 的 Value 属性。

        //上下文绑定
        //label.BindingContext = slider;
        //label.SetBinding(Label.ScaleProperty, "Value");

        //没有上下文的绑定
        label.SetBinding(Label.ScaleProperty, new Binding("Value", source: slider));

        //Viewmodels 和属性更改通知
    }
}