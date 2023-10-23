using CommunityToolkit.Maui;
using Foundation;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace Project_V;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
                   .ConfigureMauiHandlers(handlers =>
                   {
                   })
                   .UseMauiCompatibility().UseMauiCommunityToolkit();
        return builder.Build();
    }

}
