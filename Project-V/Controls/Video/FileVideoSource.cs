//类 FileVideoSource 用于访问设备视频库中的视频。 它定义 File 类型的 string属性：
namespace Project_V.Controls
{
    internal class FileVideoSource : VideoSource
    {
        public static readonly BindableProperty FileProperty =
            BindableProperty.Create(nameof(File), typeof(string), typeof(FileVideoSource));

        public string File
        {
            get { return (string)GetValue(FileProperty); }
            set { SetValue(FileProperty, value); }
        }
    }
}
