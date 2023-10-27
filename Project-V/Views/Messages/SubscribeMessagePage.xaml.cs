namespace Project_V.Views.Messages;

public partial class SubscribeMessagePage : ContentPage
{
	public SubscribeMessagePage()
	{
		InitializeComponent();
        MessagingCenter.Subscribe<SendMessagePage, string>(this, "Hi", (sender, arg) =>
        {
             element.Text = arg;
        });
    }
}