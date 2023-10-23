using Android.Content;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Project_V.Controls;
using Project_V.Platforms.Android.Renders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(CustomImage), typeof(CustomImageRenderer))]
namespace Project_V.Platforms.Android.Renders
{
    internal class CustomImageRenderer : ImageRenderer
    {
        public CustomImageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null && Control.Drawable != null)
            {
                // 获取Image控件的相关属性
                var image = Element as Image;
                var scaleFactor = image.WidthRequest / image.HeightRequest;

                // 修改图片的大小
                Control.Post(() =>
                {
                    Control.SetMinimumWidth((int)image.WidthRequest);
                    Control.SetMinimumHeight((int)image.HeightRequest);
                });
            }
        }
    }
}
