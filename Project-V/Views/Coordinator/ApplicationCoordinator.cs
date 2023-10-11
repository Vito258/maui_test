using Project_V.Views.Second;

namespace Project_V.Views.Coordinator
{
    //协调器，专门用来实现对应接口的类
    internal class ApplicationCoordinator : Models.MySideViewModel.ISideTransition
    {
        // return new NavigationPage().PushAsync(page);
        // return GetNavigationPage()?.PushAsync(page);

        // Application.Current.MainPage = page;
        // return null ;
        public async Task Image1Transition()
        {
            try
            {
                var page = new Image1Page();
                // 获取当前导航堆栈上的 NavigationPage 对象
                var navigationPage = Application.Current.MainPage as NavigationPage;
                await navigationPage.PushAsync(page);
            }
            catch (Exception ex)
            {
                throw new Exception("出错了");
            }

        }

        public async Task Image2Transition()
        {
            var page = new Image2Page();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }

        public async Task Image3Transition()
        {
            var page = new Image3Page();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }

        public async Task Image4Transition()
        {
            var page = new Image4Page();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage.PushAsync(page);
        }

        public INavigation GetNavigationPage()
        {
            try
            {
                if (Application.Current.MainPage is NavigationPage)
                {
                    return (Application.Current.MainPage as NavigationPage).Navigation;
                }
                //else if (Application.Current.MainPage is MasterDetailPage)
                //{
                //    var tabPage = (Application.Current.MainPage as MasterDetailPage).Detail as TabMultiPage;
                //    return (tabPage.Children.FirstOrDefault(e => e.IsVisible) as NavigationPage).Navigation;
                //}
                else if (Application.Current.MainPage is Shell)
                {
                    var shell = Application.Current.MainPage as Shell;
                    return shell.Navigation;
                }
                else
                {

                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
