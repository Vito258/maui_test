using Android.App;
using Android.Gms.Ads;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Plugin.MauiMTAdmob;
using Project_V.Controls;
using Project_V.Handlers;
using Project_V.Models.Domains;
using Project_V.Platforms.Android.Renders;
//using Com.Braze;
//using Firebase.Iid;

namespace Project_V;

[Application]
public class MainApplication : MauiApplication
{
    public static MainApplication? Instance;
    public MainApplication(IntPtr handle, JniHandleOwnership ownership) : base(handle, ownership)
    {
        Instance = this;
    }
    public override void OnCreate()
    {
        base.OnCreate();
        MobileAds.Initialize(this);
    }
    protected override MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiMTAdmob()
            .UseFFImageLoading()
            .ConfigureMauiHandlers(handlers =>
            {
             //handlers.AddHandler(typeof(UriImageSource), typeof(MyImageLoaderSourceHandler));
             //handlers.AddCompatibilityRenderer(typeof(GifImage), typeof(GifImageRenderer));
            }).UseMauiCompatibility().UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        AllowMultiLineTruncation();
        return builder.Build();
    }
    static void AllowMultiLineTruncation()
    {
        static void UpdateMaxLines(Microsoft.Maui.Handlers.LabelHandler handler, ILabel label)
        {
            var textView = handler.PlatformView;
            if (label is Label controlsLabel && textView.Ellipsize == TextUtils.TruncateAt.End)
            {
                textView.SetMaxLines(controlsLabel.MaxLines);
            }
        };

        Label.ControlsLabelMapper.AppendToMapping(nameof(Label.LineBreakMode), UpdateMaxLines);

        Label.ControlsLabelMapper.AppendToMapping(nameof(Label.MaxLines), UpdateMaxLines);
    }

}
