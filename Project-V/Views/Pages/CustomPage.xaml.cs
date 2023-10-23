namespace Project_V.Views.Pages;

public partial class CustomPage : ContentPage
{
    public CustomPage()
    {
        InitializeComponent();
        Uri uri = new Uri("https://t7.baidu.com/it/u=3203007717,1062852813&fm=193&f=GIF");
        image.Source = ImageSource.FromUri(uri);
        //image.Source = ImageSource.FromFile("stitch");
    }
}