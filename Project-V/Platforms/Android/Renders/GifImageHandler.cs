using Android.Graphics;
using Android.Widget;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Project_V.Handlers;
using Project_V.Models.Domains;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformView = Android.Widget.ImageView;

//[assembly: ExportRenderer(typeof(GifImage), typeof(GifImageHandler))]
namespace Project_V.Handlers
{
    public partial class GifImageHandler : ImageHandler
    {
        //private Image image;
        //public static PropertyMapper<GifImage, GifImageHandler> PropertyMapper = new PropertyMapper<GifImage, GifImageHandler>(ImageHandler.ViewMapper)
        //{

        //};

        //public GifImageHandler() : base(PropertyMapper)
        //{

        //}
        //protected override ImageView CreatePlatformView() => new PlatformView(Context);
        //protected override void ConnectHandler(ImageView platformView)
        //{
        //    base.ConnectHandler(platformView);
        //    //image = new Image { Source = "kk1.gif" };
        //    //image.IsAnimationPlaying = true;
        //    //platformView.UpdateIsAnimationPlaying(image);
        //}
        //protected override void DisconnectHandler(ImageView platformView)
        //{
        //    // Perform any native view cleanup here
        //    base.DisconnectHandler(platformView);
        //}
    }

}
