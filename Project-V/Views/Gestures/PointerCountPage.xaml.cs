using Project_V.Models;

namespace Project_V.Views.Gestures;

public partial class PointerCountPage : ContentPage
{
    //指针手势识别仅在 iPadOS、Mac Catalyst 和 Windows 上受支持。
    public MyBindingModel ViewModel { get; set; }
    public PointerCountPage()
	{
		InitializeComponent();
        ViewModel = MyBindingModel.NewInstance();
        BindingContext = ViewModel;
        ViewModel.Color = Color.FromRgb(220, 20, 60);
    }
    void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ViewModel.Color = Color.FromRgb(0, 255, 127);
    }

    void OnPointerExited(object sender, PointerEventArgs e)
    {
        ViewModel.Color = Color.FromRgb(220, 20, 60);
    }

    void OnPointerMoved(object sender, PointerEventArgs e)
    {
        // Handle the pointer moved event
    }
}