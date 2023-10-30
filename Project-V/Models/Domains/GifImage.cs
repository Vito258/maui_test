using System.Runtime.CompilerServices;

namespace Project_V.Models.Domains
{
    public class GifImage : Image
    {
        protected async override void OnParentSet()
        {
            base.OnParentSet();

            for (int i = 0; i < 1000; i++)
            { 
            await Task.Delay(1);
            IsAnimationPlaying = false;
            await Task.Delay(1);
            IsAnimationPlaying = true;
            }
               
        }

        protected override void OnParentChanging(ParentChangingEventArgs args)
        {
            base.OnParentChanging(args);
        }



        //protected async override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);
        //    await Task.Delay(1);
        //    IsAnimationPlaying = false;
        //    await Task.Delay(1);
        //    IsAnimationPlaying = true;
        //}

        //protected async override void OnHandlerChanged()
        //{
        //    base.OnHandlerChanged();
        //    await Task.Delay(1);
        //    IsAnimationPlaying = false;
        //    await Task.Delay(1);
        //    IsAnimationPlaying = true;
        //}

        //protected async override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();
        //    await Task.Delay(1);
        //    IsAnimationPlaying = false;
        //    await Task.Delay(1);
        //    IsAnimationPlaying = true;
        //}
    }
}
