using Project_V.Models;

namespace Project_V.Views.Pages
{
    public partial class AboutPage
    {
        public AboutPage()
        {
        }

        public AboutPage(AboutPageViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }
    }
}
