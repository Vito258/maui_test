namespace Project_V.Views.Gestures;

public partial class TapPage : ContentPage
{
    private int i;
    public TapPage()
	{
		InitializeComponent();
	}

    private void OnTapped(object sender, TappedEventArgs e)
    {
        i++;
        button.Text = i.ToString();

        //返回位置信息的方法
        // Position inside window
        Point? windowPosition = e.GetPosition(null);

        // Position relative to an Button
        Point? relativeToImagePosition = e.GetPosition(button);

        // Position relative to the container view
        Point? relativeToContainerPosition = e.GetPosition((View)sender);
    }
}