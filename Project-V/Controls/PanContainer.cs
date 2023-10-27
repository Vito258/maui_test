using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_V.Controls
{
    //创建平移容器
    //任意多边形平移通常适用于在图像和地图中导航。 PanContainer类（如以下示例所示）是执行任意多边形平移的通用化帮助程序类：
    public class PanContainer : ContentView
    {
        double panX, panY;

        public PanContainer()
        {
            // Set PanGestureRecognizer.TouchPoints to control the
            // number of touch points needed to pan
            PanGestureRecognizer panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and pan.
                    double boundsX = Content.Width;
                    double boundsY = Content.Height;
                    Content.TranslationX = Math.Clamp(panX + e.TotalX, -boundsX, boundsX);
                    Content.TranslationY = Math.Clamp(panY + e.TotalY, -boundsY, boundsY);
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    panX = Content.TranslationX;
                    panY = Content.TranslationY;
                    break;
            }
        }
    }
}
