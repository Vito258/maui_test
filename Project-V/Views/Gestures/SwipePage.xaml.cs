namespace Project_V.Views.Gestures;

public partial class SwipePage : ContentPage
{
    //RGB的值
    private int red;
    private int green;
    private int blue;
	public SwipePage()
	{
		InitializeComponent();
	}

    private void OnSwiped(object sender, SwipedEventArgs e)
    {
        //相应轻扫
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                RandomValue();
                boxview.Color = Color.FromRgb(red, green, blue);
                break;
            case SwipeDirection.Right:
                // Handle the swipe
                break;
            case SwipeDirection.Up:
                // Handle the swipe
                break;
            case SwipeDirection.Down:
                // Handle the swipe
                break;
        }

    }

    //生成3个0-255 的随机数，并将其赋值给RGB
    private void RandomValue()
    {
        Random random = new Random();
        red = random.Next(0, 255);
        green = random.Next(0, 255);
        blue = random.Next(0, 255);
    }

}