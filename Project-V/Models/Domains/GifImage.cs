namespace Project_V.Models.Domains
{
    public class GifImage : Image
    {
        protected async override void OnParentSet()
        {
            base.OnParentSet();
            await Task.Delay(100);
            IsAnimationPlaying = false;
            await Task.Delay(100);
            IsAnimationPlaying = true;
        }
    }
}
