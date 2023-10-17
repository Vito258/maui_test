
using Project_V.Views.Coordinator;
using Project_V.Views.Pages;

namespace Project_V;

public partial class App : Application
{
    //全局注册
    private ApplicationCoordinator coordinator;
    static TodoItemDatabase database;
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new ControlTemplatePage());
    }

    public static TodoItemDatabase DataBase
    {
        get
        {
            if (database == null)
            {
                // Android:  /data/user/0/net.fukuri.memberapp.memberapp/files/ReloClubSQLite.db
                //     iOS:  /var/mobile/Containers/Data/Application/5B6296CA-4F17-4C32-9791-5A63C395AF5A/Documents/ReloClubSQLite.db
                var dbPath = Path.Combine(Environment.GetFolderPath(DeviceInfo.Platform == DevicePlatform.Android ? Environment.SpecialFolder.Personal : Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFilename);
                database = new TodoItemDatabase(dbPath);
            }
            return database;
        }
    }

    public static App Instance { set; get; }
    //在当前应用程序的协调器对象中查找指定泛型类型 T 的实例，如果找到则返回该实例，否则返回默认值。
    //public static T GetTransition<T>() where T : class
    //{
    //    var app = Current as App;
    //    var coordinator = app.coordinator;
    //    if (coordinator is T)
    //    {
    //        return coordinator as T;
    //    }
    //    return default(T);
    //}
}
