namespace Project_V.Controls.Interface
{
    public interface IVideoController
    {
        public enum VideoStatus
        {
            NotReady,
            Playing,
            Paused
        }
        VideoStatus Status { get; set; }
        TimeSpan Duration { get; set; }

    }
}
