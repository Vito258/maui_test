using Project_V.Controls.Interface;
//using Project_V.Handlers;
using System.ComponentModel;

//若要创建跨平台控件，应创建派生自 View的类：
namespace Project_V.Controls
{
    public class Video : View, IVideoController
    {
        public static readonly BindableProperty AreTransportControlsEnabledProperty =
            BindableProperty.Create(nameof(AreTransportControlsEnabled), typeof(bool), typeof(Video), true);

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(VideoSource), typeof(Video), null);

        public static readonly BindableProperty AutoPlayProperty =
            BindableProperty.Create(nameof(AutoPlay), typeof(bool), typeof(Video), true);

        public static readonly BindableProperty IsLoopingProperty =
            BindableProperty.Create(nameof(IsLooping), typeof(bool), typeof(Video), false);

        private static readonly BindablePropertyKey StatusPropertyKey =
          BindableProperty.CreateReadOnly(nameof(Status), typeof(VideoStatus), typeof(Video), VideoStatus.NotReady);

        public static readonly BindableProperty StatusProperty = StatusPropertyKey.BindableProperty;

        private static readonly BindablePropertyKey DurationPropertyKey =
           BindableProperty.CreateReadOnly(nameof(Duration), typeof(TimeSpan), typeof(Video), new TimeSpan(),
               propertyChanged: (bindable, oldValue, newValue) => ((Video)bindable).SetTimeToEnd());

        public static readonly BindableProperty DurationProperty = DurationPropertyKey.BindableProperty;

        public static readonly BindableProperty PositionProperty =
           BindableProperty.Create(nameof(Position), typeof(TimeSpan), typeof(Video), new TimeSpan(),
               propertyChanged: (bindable, oldValue, newValue) => ((Video)bindable).SetTimeToEnd());

        private static readonly BindablePropertyKey TimeToEndPropertyKey =
           BindableProperty.CreateReadOnly(nameof(TimeToEnd), typeof(TimeSpan), typeof(Video), new TimeSpan());

        public static readonly BindableProperty TimeToEndProperty = TimeToEndPropertyKey.BindableProperty;

        public TimeSpan TimeToEnd
        {
            get { return (TimeSpan)GetValue(TimeToEndProperty); }
            private set { SetValue(TimeToEndPropertyKey, value); }
        }

        void SetTimeToEnd()
        {
            TimeToEnd = Duration - Position;
        }

        public TimeSpan Position
        {
            get { return (TimeSpan)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        //public TimeSpan Duration
        //{
        //    get { return (TimeSpan)GetValue(DurationProperty); }
        //}

        TimeSpan IVideoController.Duration
        {
            get { return Duration; }
            set { SetValue(DurationPropertyKey, value); }
        }


        public event EventHandler UpdateStatus;

        IDispatcherTimer _timer;


        public Video()
        {
            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        ~Video() => _timer.Tick -= OnTimerTick;

        void OnTimerTick(object sender, EventArgs e)
        {
            UpdateStatus?.Invoke(this, EventArgs.Empty);
            Handler?.Invoke(nameof(Video.UpdateStatus));
        }
        public enum VideoStatus
        {
            NotReady,
            Playing,
            Paused
        }

        public event EventHandler<VideoPositionEventArgs> PlayRequested;
        public event EventHandler<VideoPositionEventArgs> PauseRequested;
        public event EventHandler<VideoPositionEventArgs> StopRequested;


        public VideoStatus Status
        {
            get { return (VideoStatus)GetValue(StatusProperty); }
        }

        //VideoStatus IVideoController.Status
        //{
        //    get { return Status; }
        //    set { SetValue(StatusPropertyKey, value); }
        //}
        public void Play()
        {
            VideoPositionEventArgs args = new VideoPositionEventArgs(Position);
            PlayRequested?.Invoke(this, args);
            Handler?.Invoke(nameof(Video.PlayRequested), args);
        }

        public void Pause()
        {
            VideoPositionEventArgs args = new VideoPositionEventArgs(Position);
            PauseRequested?.Invoke(this, args);
            Handler?.Invoke(nameof(Video.PauseRequested), args);
        }

        public void Stop()
        {
            VideoPositionEventArgs args = new VideoPositionEventArgs(Position);
            StopRequested?.Invoke(this, args);
            Handler?.Invoke(nameof(Video.StopRequested), args);
        }
        public bool AreTransportControlsEnabled
        {
            get { return (bool)GetValue(AreTransportControlsEnabledProperty); }
            set { SetValue(AreTransportControlsEnabledProperty, value); }
        }

        //public static void MapIsLooping(VideoHandler handler, Video video)
        //{
        //    handler.PlatformView?.UpdateIsLooping();
        //}

        [TypeConverter(typeof(VideoSourceConverter))]
        public VideoSource Source
        {
            get { return (VideoSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public bool AutoPlay
        {
            get { return (bool)GetValue(AutoPlayProperty); }
            set { SetValue(AutoPlayProperty, value); }
        }

        public bool IsLooping
        {
            get { return (bool)GetValue(IsLoopingProperty); }
            set { SetValue(IsLoopingProperty, value); }
        }


        public TimeSpan Duration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IVideoController.VideoStatus IVideoController.Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
