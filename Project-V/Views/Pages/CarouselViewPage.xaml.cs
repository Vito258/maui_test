namespace Project_V.Views.Pages;

public partial class CarouselViewPage : ContentPage
{
    public CarouselViewPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var dataTemplate = carouselView.FindByName("dataTemplate") as DataTemplate;
        //dataTemplate
        //DisplayAlert("title", image.ToString(), "cancel");
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        //Image image =  sender as Image;
        //DisplayAlert("title", sender.GetLocation, "cancel");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //carouselView.On
        //object o  = carouselView.CurrentItem;
        //DisplayAlert("title", o.ToString(), "cancel");
    }
}