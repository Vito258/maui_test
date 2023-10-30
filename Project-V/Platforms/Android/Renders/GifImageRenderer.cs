using Android.Content;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;
using Project_V.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_V.Platforms.Android.Renders
{
    public class GifImageRenderer : ImageRenderer
    {
        public GifImageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null && Control.Drawable != null)
            {
              
                // 获取Image控件的相关属性
                GifImage image = Element as GifImage;
                image.IsAnimationPlaying = true;
                // 修改图片
                Control.Post(() =>
                    {
                        Control.UpdateIsAnimationPlaying(image);
                        Control.Invalidate();
                    });
            }
        }
    }
}
