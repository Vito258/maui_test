using Android.App;
using Android.Gms.Ads;
using Android.Runtime;
using CommunityToolkit.Maui;
using Project_V.Handlers;
using Project_V.Models.Domains;
//using Com.Braze;
//using Firebase.Iid;

namespace Project_V;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }
    public override void OnCreate()
    {
        base.OnCreate();

        MobileAds.Initialize(this);

        //加载广告
        //AdView ads = new AdView(MainActivity.Instance);
        //MTAdView ad = new MTAdView();
        //ad.PersonalizedAds = true;
        //new Task(RegisterFirebasePush).Start();
    }

    protected override MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(GifImage), typeof(GifImageHandler));
            });
        return builder.Build();
    }
    //void RegisterFirebasePush()
    //{
    //    try
    //    {
    //        var token = FirebaseInstanceId.Instance.GetToken("356661937358", "FCM");
    //        Braze.GetInstance(this).RegisteredPushToken = token;
    //        Console.WriteLine("Registered Firebase push token with Braze: " + token);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine("Caught exception registering for Firebase push: " + e);
    //    }
    //}

}
