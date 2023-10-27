using Project_V.Controls;
using Project_V.Models;

namespace Project_V.Views.Gestures;

public partial class DragAndDropPage : ContentPage
{
    public DragAndDropPage()
	{
		InitializeComponent();        
        ViewModel = MyBindingModel.NewInstance();
        BindingContext = ViewModel;
	}

    public MyBindingModel ViewModel { get; set; }
    public void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        e.Data.Text = "My text data goes here";
    }
    public async void BoxConsume(object sender, DropEventArgs e)
    {
          ViewModel.Text = await e.Data.GetTextAsync();     //读取到的只是携带的数据包的内容，如果拖动的是Label，不能直接读取到Label.Text
          
    }

    //private void OnDragOver(object sender, DragEventArgs e)
    //{
    //      label.IsVisible = false;
    //}

    //public async void OnDrop(object sender, DropEventArgs e)
    //{
    //    label.IsVisible = true;
    //}
}