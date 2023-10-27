using CommunityToolkit.Mvvm.Messaging;

namespace Project_V.Views.Messages;

public partial class SendMessagePage : ContentPage
{
	public SendMessagePage()
	{
		InitializeComponent();
		Send();
	}

	void Send()
	{
	  string message =	label.Text;
      MessagingCenter.Send<SendMessagePage, string>(this, "Hi", message);
      WeakReferenceMessenger.Default.Send(message);
	  
    }
}