

namespace Project_V.Views.Messages;

public partial class MessagePage : ContentPage
{
	public MessagePage()
	{
		InitializeComponent();

        //发送方   
        //1.泛型参数指定发送方类型，第一个方法参数指定发送方实例，第二个方法参数指定消息。
        MessagingCenter.Send<MessagePage>(this, "Hi");

        //2.通过消息发送有效负载消息，
        //两个泛型参数。 第一个参数是发送消息的类型，第二个参数是发送的有效负载数据的类型。
        //此示例指定第三个方法参数，该参数表示要发送到订阅方的有效负载数据。
        MessagingCenter.Send<MessagePage, string>(this, "Hi", "John");


        //订阅方
        //1.订阅方可以使用一种 MessagingCenter.Subscribe 重载进行注册以接收消息。 下面的代码示例演示了此示例：
        MessagingCenter.Subscribe<MessagePage>(this, "Hi", (sender) =>
        {
            // Do something whenever the "Hi" message is received
        });

        //2.以下示例显示如何订阅包含有效负载数据的消息：
        MessagingCenter.Subscribe<MessagePage, string>(this, "Hi", async (sender, arg) =>
        {
            await DisplayAlert("Message received", "arg=" + arg, "OK");
        });

        //取消订阅消息
        MessagingCenter.Unsubscribe<MessagePage, string>(this, "Hi");
    }
}