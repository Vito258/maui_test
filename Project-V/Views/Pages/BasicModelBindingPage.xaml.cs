using Project_V.Models;
using Project_V.Models.Domains;
using System.Collections.ObjectModel;

namespace Project_V.Views.Pages;

public partial class BasicModelBindingPage : ContentPage
{
    public BasicModelBindingPage()
    {
        InitializeComponent();

        //在后台实现数据的多重绑定
        //BindingContext = new GroupViewModel();

        //CheckBox checkBox = new CheckBox();
        //checkBox.SetBinding(CheckBox.IsCheckedProperty, new MultiBinding
        //{
        //    Bindings = new Collection<BindingBase>
        //{
        //    new Binding("Employee1.IsOver16"),
        //    new Binding("Employee1.HasPassedTest"),
        //    new Binding("Employee1.IsSuspended", converter: new InverterConverter())
        //},
        //    Converter = new AllTrueMultiConverter()
        //});

        //Title = "BasicModelBindingPage";
        //Content = checkBox;

        //在后台实现字符串多重绑定结果的格式化
        //    Label label = new Label();
        //    label.SetBinding(Label.TextProperty, new MultiBinding
        //    {
        //        Bindings = new Collection<BindingBase>
        //{
        //    new Binding("Employee1.Forename"),
        //    new Binding("Employee1.MiddleName"),
        //    new Binding("Employee1.Surname")
        //},
        //        StringFormat = "{0} {1} {2}"
        //    });
        //}
    }
}