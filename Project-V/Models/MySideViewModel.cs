using Mopups.Services;
using Project_V.Views.Second;

namespace Project_V.Models
{
    public class MySideViewModel
    {
        //定义实现跳转的接口
        public interface ISideTransition
        {
            //image1Page
            Task Image1Transition();

            //image2Page
            Task Image2Transition();

            //image3Page
            Task Image3Transition();

            //image4Page
            Task Image4Transition();

        }

        //image1Page
        public async Task Image1Transition()
        {
            var page = new Image1Page();
            // 获取当前导航堆栈上的 NavigationPage 对象
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }

        //image2Page
        public async Task Image2Transition()
        {
            var page = new Image2Page();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }

        //image3Page
        public async Task Image3Transition()
        {
            var page = new Image3Page();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }

        //image4Page
        public async Task Image4Transition()
        {
            var page = new Image4Page();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }
        //private ApplicationCoordinator coordinator;
        //关闭侧边栏的方法
        private Task CloseMenu()
        {
            return MopupService.Instance.PopAsync();
        }
        // App.GetTransition<ISideTransition>()?.Image2Transition();
        public async void Image1CommandAsync()
        {
            //await CloseMenu();         //关闭侧边栏的显示
            //Task task = Image1Transition();
            //task.Start();
            await Image1Transition();
        }
        public async void Image2CommandAsync()
        {
            //await CloseMenu();         //关闭侧边栏的显示
            await Image2Transition();
        }
        public async void Image3CommandAsync()
        {
            //await CloseMenu();         //关闭侧边栏的显示
            await Image3Transition();
        }
        public async void Image4CommandAsync()
        {
            //await CloseMenu();         //关闭侧边栏的显示
            await Image4Transition();
        }

    }
}
