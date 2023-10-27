using Project_V.Models.Domains;

namespace Project_V.Views.Pages;

public partial class CarouselViewPage : ContentPage
{
    public CarouselViewPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void OnTapped(object sender, TappedEventArgs e)
    {
        string name = "";
        //name = e.GetPosition(this).ToString();
        //name = sender.GetType().Name;
   
        DisplayAlert("title", name, "cancel");
    }
}