using Project_V.Models;

//实现侧边栏，创建一个侧边栏的View对象，在需要调用侧边栏的Page调用
namespace Project_V.Views.Pages
{
    public partial class MySideView : ContentView
    {
        //创建一个枚举类
        enum ContentViewType
        {
            side_image1,
            side_image2,
            side_image3,
            side_image4
        }
        //创建一个Dictionary对象，实现枚举类的值向string字符串的转换
        Dictionary<ContentViewType, string> viewPairs = new Dictionary<ContentViewType, string>()
        {
            {ContentViewType.side_image1,"页面：图像1" },
            {ContentViewType.side_image2,"页面：图像2" },
            {ContentViewType.side_image3,"页面：图像3" },
            {ContentViewType.side_image4,"页面：图像4" },
    };

        //用于数据绑定的Model
        MySideViewModel viewModel;
        public MySideView()
        {
            InitializeComponent();
            viewModel = new MySideViewModel();
            SetList();
        }
        //设置显示菜单内容
        private void SetList()
        {
            foreach (var contentViewType in Enum.GetValues(typeof(ContentViewType)))
            {
                ContentViewType contentView = (ContentViewType)Enum.Parse(typeof(ContentViewType), contentViewType.ToString());

                ContentTypeSet(contentView);
            }

        }
        //设置菜单栏各项的属性
        private void ContentTypeSet(ContentViewType contentViewType)
        {
            //创建一个 Label 控件，设置其属性和边距，并将其放置在一个水平的 StackLayout 中
            TapGestureRecognizer tgr = new TapGestureRecognizer();
            Label lb = new Label();
            lb.HorizontalTextAlignment = TextAlignment.Start;
            lb.VerticalTextAlignment = TextAlignment.Center;
            lb.CharacterSpacing = 2;
            //创建了一个绑定，引用创建的字典类，并将绑定应用到 lb 的 TextProperty 上
            //lb.SetBinding(Label.TextProperty, new Binding(viewPairs[contentViewType]));
            lb.Text = viewPairs[contentViewType];
            lb.Margin = new Thickness(10, 10, 0, 10);
            lb.TextColor = Color.FromArgb("#000000");
            lb.FontSize = 18;
            StackLayout layout = new StackLayout();
            layout.Orientation = StackOrientation.Horizontal;
            layout.Children.Add(lb);

            //给image4这一栏加一个图片
            if (contentViewType.Equals(ContentViewType.side_image4))
            {
                lb.HorizontalOptions = LayoutOptions.Start;
                var image = new Image();
                image.Margin = new Thickness(0, 0, 15, 0);
                image.Source = ImageSource.FromFile("external_site_01.png");
                image.HorizontalOptions = LayoutOptions.EndAndExpand;
                image.VerticalOptions = LayoutOptions.CenterAndExpand;
                image.HeightRequest = 20;
                image.WidthRequest = 20;
                layout.Children.Add(image);
            }
            //绑定页面跳转的方法
            switch (contentViewType)
            {
                case ContentViewType.side_image1:
                    tgr.Tapped += Image1_Tapped;
                    break;
                case ContentViewType.side_image2:
                    tgr.Tapped += Image2_Tapped;
                    break;
                case ContentViewType.side_image3:
                    tgr.Tapped += Image3_Tapped;
                    break;
                case ContentViewType.side_image4:
                    tgr.Tapped += Image4_Tapped;
                    break;
            }
            ContentView cv = new ContentView();
            if (contentViewType.Equals(ContentViewType.side_image4))
            {
                cv.Content = layout;
            }
            else
            {
                cv.Content = lb;
            }

            cv.GestureRecognizers.Add(tgr);
            xStackLayout.Children.Add(cv);
            AddBoxView();
        }

        private void AddBoxView()
        {
            BoxView bv = new BoxView();
            bv.BackgroundColor = Color.FromArgb("#222222");
            bv.HeightRequest = 0.5;
            bv.HorizontalOptions = LayoutOptions.Fill;
            bv.Margin = new Thickness(10, 0, 10, 0);

            xStackLayout.Children.Add(bv);
        }

        void Image1_Tapped(object sender, EventArgs e)
        {
            viewModel.Image1CommandAsync();
        }
        void Image2_Tapped(object sender, EventArgs e)
        {
            viewModel.Image2CommandAsync();
        }
        void Image3_Tapped(object sender, EventArgs e)
        {
            viewModel.Image3CommandAsync();
        }
        void Image4_Tapped(object sender, EventArgs e)
        {
            viewModel.Image4CommandAsync();
        }
    }
}
