namespace Project_V.Views.Pages;

public partial class GifPage : ContentPage
{
    public static GifPage Instance { get; private set; }
    
    public GifPage()
    {
        InitializeComponent();
        Instance = this;
        gif.IsAnimationPlaying = true;
    }
    

    public static void GifAnimationPlaying()
    {
        Instance.gif.IsAnimationPlaying = true;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // 在此处设置按钮的属性
       gif.IsAnimationPlaying = true;
    }
}