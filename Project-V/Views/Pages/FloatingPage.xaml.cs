namespace Project_V
{
    public partial class FloatingPage : ContentPage
    {
        public FloatingPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                //创建100个Label控件
                Label label = new Label();
                label.Text = "Test : 第" + i + "列";
                label.BackgroundColor = Color.FromArgb("#E6E6FA");
                label.WidthRequest = 50;
                label.HorizontalOptions = LayoutOptions.Center;
                label.VerticalOptions = LayoutOptions.Center;

                //将label添加到Layout
                vsl.Children.Add(label);
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("提示", "点击了悬浮按钮", "确定");
            //ImageSource imagesource = null;
            //var imageLoader = imagesource as StreamImageSource;
            ////UriImageSource source = new UriImageSource();
            //StreamImageSource = imageLoader as IStreamImageSource;
            //IStreamImageSource source = new UriImageSource();
            //source.GetStreamAsync();


            IStreamImageSource source = new UriImageSource();


        }
    }
}
