namespace Project_V.Controls
{
    public class VideoPositionEventArgs
    {
        TimeSpan Position;

        public VideoPositionEventArgs(TimeSpan Position) { }
        public TimeSpan Position1 { get => Position; set => Position = value; }
        //public TimeSpan Position
        //{
        //    get { return (TimeSpan)GetValue(PositionProperty); }
        //    set { SetValue(PositionProperty, value); }
        //}
    }
}
