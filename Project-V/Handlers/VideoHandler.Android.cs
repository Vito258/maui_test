using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Project_V.Controls;
using Project_V.Platforms.Android;

namespace Project_V.Handlers
{
    public partial class VideoHandler : ViewHandler<Video, MauiVideoPlayer>
    {
        //public VideoHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) : base(mapper, commandMapper)
        //{
        public static IPropertyMapper<Video, VideoHandler> PropertyMapper = new PropertyMapper<Video, VideoHandler>(ViewHandler.ViewMapper)
        {
            [nameof(Video.AreTransportControlsEnabled)] = MapAreTransportControlsEnabled,
            [nameof(Video.Source)] = MapSource,
            [nameof(Video.IsLooping)] = MapIsLooping,
            [nameof(Video.Position)] = MapPosition
        };
        public static CommandMapper<Video, VideoHandler> CommandMapper = new(ViewCommandMapper)
        {
            [nameof(Video.UpdateStatus)] = MapUpdateStatus,
            [nameof(Video.PlayRequested)] = MapPlayRequested,
            [nameof(Video.PauseRequested)] = MapPauseRequested,
            [nameof(Video.StopRequested)] = MapStopRequested
        };

        public VideoHandler() : base(PropertyMapper, CommandMapper)
        {
        }



        protected override MauiVideoPlayer CreatePlatformView() => new MauiVideoPlayer(Context, VirtualView);

        protected override void ConnectHandler(MauiVideoPlayer platformView)
        {
            base.ConnectHandler(platformView);

            // Perform any control setup here
        }

        protected override void DisconnectHandler(MauiVideoPlayer platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        public static void MapAreTransportControlsEnabled(VideoHandler handler, Video video)
        {
            handler?.PlatformView.UpdateTransportControlsEnabled();
        }

        public static void MapSource(VideoHandler handler, Video video)
        {
            handler.PlatformView?.UpdateSource();

            // Convert cross-platform control to its underlying platform control
            MauiVideoPlayer mvp = (MauiVideoPlayer)video.ToPlatform(handler.MauiContext);
        }
        public static void MapIsLooping(VideoHandler handler, Video video)
        {
            handler.PlatformView?.UpdateIsLooping();
        }
        public static void MapPosition(VideoHandler handler, Video video)
        {
            handler.PlatformView?.UpdatePosition();
        }

        public static void MapUpdateStatus(VideoHandler handler, Video video, object? args)
        {
            handler.PlatformView?.UpdateStatus();
        }

        public static void MapPlayRequested(VideoHandler handler, Video video, object? args)
        {
            if (args is not VideoPositionEventArgs)
                return;

            TimeSpan position = ((VideoPositionEventArgs)args).Position1;
            handler.PlatformView?.PlayRequested(position);
        }

        public static void MapPauseRequested(VideoHandler handler, Video video, object? args)
        {
            if (args is not VideoPositionEventArgs)
                return;

            TimeSpan position = ((VideoPositionEventArgs)args).Position1;
            handler.PlatformView?.PauseRequested(position);
        }

        public static void MapStopRequested(VideoHandler handler, Video video, object? args)
        {
            if (args is not VideoPositionEventArgs)
                return;

            TimeSpan position = ((VideoPositionEventArgs)args).Position1;
            handler.PlatformView?.StopRequested(position);
        }
    }
}
