using Project_V.Models;

namespace Project_V.Views.Pages
{
    //用于试验控件的页面
    public partial class MyTestPage : ContentPage
    {
        public MyTestPage()
        {
            InitializeComponent();
        }

        //public MyTestPage()
        //{
        //    InitializeComponent();
        //    // 添加视图到ContentView
        //    //MySideView customView = new MySideView();
        //    //SideMenuView.Content = customView;
        //}

        public MyTestPage(MyTestPageViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }


        public void ImageButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("提示", "点击按钮事件触发", "确定");

        }
        private void MainPage_Appearing(object sender, EventArgs e)
        {
            ((MyTestPageViewModel)BindingContext).InitializeCollectionCommand.Execute(null);
        }

        private void MainPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            notesCollection.SelectedItem = null;
        }
    }
}
