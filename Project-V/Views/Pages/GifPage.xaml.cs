namespace Project_V.Views.Pages;

public partial class GifPage : ContentPage
{
    public static GifPage Instance { get; private set; }

    public GifPage()
    {
        InitializeComponent();
        Instance = this;

    }
    //protected async override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    await Task.Delay(100);
    //    gif.IsAnimationPlaying = false;
    //    await Task.Delay(100);
    //    gif.IsAnimationPlaying = true;
    //}
}