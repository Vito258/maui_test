using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using Plugin.MauiMTAdmob;
using Project_V.Models;
using Project_V.Views.Pages;

namespace Project_V;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiMTAdmob()
            .UseFFImageLoading()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        //.ConfigureMauiHandlers(handlers =>
        // {
        //     handlers.AddHandler(typeof(GifImage), typeof(GifImageHandler));
        // });

        /*
         * 使用依赖项注入TodoItemDataBase
         * 使用AddSingleton 和 AddTransient 方法在 MauiProgram.cs 中将页面和数据库访问类注册为IServiceCollection 对象上的服务：
         */
        //builder.Services.AddSingleton<TodoListPage>();
        builder.Services.AddTransient<TodoItemPage>();
        builder.Services.AddSingleton<TodoItemDatabase>();

        //注册service,viewmodels views;
        builder.Services.AddSingleton<MyTestPage, MyTestPageViewModel>();
        builder.Services.AddSingletonWithShellRoute<StudentPage, StudentPageViewModel>($"{nameof(StudentPage)}");

        // 连接数据库
        //builder.ConfigureEffects((_, effects) =>
        //{
        //    var database = _.Services.GetRequiredService();
        //    database.Connect();
        //});

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();


    }



}
