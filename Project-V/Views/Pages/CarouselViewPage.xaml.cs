using static System.Net.Mime.MediaTypeNames;
using Image = Microsoft.Maui.Controls.Image;

namespace Project_V.Views.Pages;

public partial class CarouselViewPage : ContentPage
{
	public CarouselViewPage()
	{
		InitializeComponent();
    }

    //protected override void OnAppearing()
    //{
    //    var image = carouselView.FindByName("image");
    //    DisplayAlert("title", image.ToString(), "cancel");
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var dataTemplate = carouselView.FindByName("dataTemplate") as DataTemplate;
        //dataTemplate
        //DisplayAlert("title", image.ToString(), "cancel");
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
       //Image image =  sender as Image;
       // DisplayAlert("title", sender.GetLocation, "cancel");
    }
}