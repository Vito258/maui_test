namespace Project_V.Models
{
    public class AboutPageViewModel
    {
        public static string AppName => $"程序名称：{AppInfo.Name}";
        public static string Vertion => $"版本：{AppInfo.VersionString}";

        public static string MoreMessage => $"使用MAUI架构，C#语言，xaml设计界面，使用IOC容器技术。";
    }
}
