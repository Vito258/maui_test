namespace Project_V.Views.Pages;

public partial class BindPage : ContentPage
{
    public BindPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string text = button.Text;
        DisplayAlert("title", text + "按钮已触发", "cancel");
    }
}