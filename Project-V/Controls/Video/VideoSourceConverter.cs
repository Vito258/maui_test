using System.ComponentModel;

namespace Project_V.Controls
{
    //在 XAML 中将 Source 属性设置为字符串时，将调用类型转换器。 ConvertFromInvariantString 方法尝试将字符串转换为 Uri 对象。
    //如果成功，并且方案不是 file，则该方法返回 UriVideoSource。 否则，它将返回 ResourceVideoSource。
    public class VideoSourceConverter : TypeConverter, IExtendedTypeConverter
    {
        object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Uri uri;
                return Uri.TryCreate(value, UriKind.Absolute, out uri) && uri.Scheme != "file" ?
                    VideoSource.FromUri(value) : VideoSource.FromResource(value);
            }
            throw new InvalidOperationException("Cannot convert null or whitespace to VideoSource.");
        }
    }
}
