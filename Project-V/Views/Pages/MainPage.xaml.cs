using Project_V.Models;
using Project_V.Views.First;
using Project_V.Views.Second;
using System.Diagnostics;
using System.Reflection;

namespace Project_V;

public partial class MainPage : ContentPage
{

    private ImageControlModel imageControlModel;

    public MainPage()
    {
        InitializeComponent();
        //Thread thread = new Thread(() =>
        //{
        //});
        //thread.Start();

        imageControlModel = new ImageControlModel();
        BindingContext = imageControlModel;

        // 每隔一段时间切换图片
        Dispatcher.StartTimer(TimeSpan.FromSeconds(10), () =>
        {
            SlideOut();

            // 切换图片
            imageControlModel.ShowImage();

            SlideIn();
            return true;
        });
        // 注册根路由
        Routing.RegisterRoute("myapp://page1", typeof(F1Page));
        Routing.RegisterRoute("myapp://page2", typeof(F2Page));

    }

    //层级路由跳转
    private async void GoToPage1_Clicked(object sender, EventArgs e)
    {
        // 导航到Page1
        await Navigation.PushAsync(new F1Page());
    }

    private async void GoToPage2_Clicked(object sender, EventArgs e)
    {
        // 导航到Page2
        await Navigation.PushAsync(new F2Page());
    }
    private async void FromImage(object sender, EventArgs e)
    {
        // 将sender转换为ImageButton类型
        var imageButton = (ImageButton)sender;
        // 在这里进行ImageButton的操作


        // 检查转换是否成功
        if (imageButton != null)
        {
            switch (imageButton.Source.ToString())
            {
                case "File: image1.jpg":
                    await Navigation.PushAsync(new Image1Page());
                    break;

                case "File: image2.jpg":
                    await Navigation.PushAsync(new Image2Page());
                    break;

                case "File: image3.jpg":
                    await Navigation.PushAsync(new Image3Page());
                    break;

                case "File: image4.jpg":
                    await Navigation.PushAsync(new Image4Page());
                    break;
            }
        }

        // 导航到MusicPage
        //await Navigation.PushAsync(new MusicPage());
    }

    private void ToFloatingPage(object sender, EventArgs e)
    {
        NavigationPage floatingPage = new NavigationPage(new FloatingPage());
        floatingPage.BarBackgroundColor = Color.FromRgba("#3E8EED");
        floatingPage.BarTextColor = Color.FromRgba("#FFFFFF");
        Application.Current.MainPage = floatingPage;                //通过这种方法跳转页面无法返回到原页面，适用于类似从初始屏幕、登录页面的跳转

    }

    private void LastImage(object sender, EventArgs e)
    {
        SlideOut();
        //切换下一张图片
        imageControlModel.SwitchToNextImage();
        SlideIn();
    }

    private void NextImage(object sender, EventArgs e)
    {
        SlideOut();
        imageControlModel.SwitchToLastImage();
        SlideIn();
    }

    //图片出视图的方法
    private async void SlideOut()
    {
        MethodBase method = new StackFrame(1).GetMethod();
        string callerMethodName = method.Name;
        var slideOutAnimation = new Animation();
        if ("LastImage".Equals(callerMethodName))
        {
            //平移出
            slideOutAnimation = new Animation(v => imageControl.TranslationX = v, 0, 200);
            // 启动动画
            imageControl.Animate("SlideAnimation", slideOutAnimation, 60, 500);
        }
        else
        {
            //平移出
            slideOutAnimation = new Animation(v => imageControl.TranslationX = v, 0, -200);
            // 启动动画
            imageControl.Animate("SlideAnimation", slideOutAnimation, 60, 500);
            await Task.Delay(1000);
        }

    }
    //图片进入视图的方法
    private void SlideIn()
    {
        MethodBase method = new StackFrame(1).GetMethod();
        string callerMethodName = method.Name;
        var slideInAnimation = new Animation();

        if ("LastImage".Equals(callerMethodName))
        {
            //平移出
            slideInAnimation = new Animation(v => imageControl.TranslationX = v, -200, 0);
            // 启动动画
            imageControl.Animate("SlideAnimation", slideInAnimation, 60, 500);
        }
        else
        {
            //平移入
            slideInAnimation = new Animation(v => imageControl.TranslationX = v, 200, 0);
            imageControl.Animate("SlideAnimation", slideInAnimation, 60, 500);
        }


    }
}

