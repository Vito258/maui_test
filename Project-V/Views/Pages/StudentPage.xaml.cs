using Project_V.Models;

namespace Project_V.Views.Pages
{
    public partial class StudentPage : ContentPage
    {
        public StudentPage(StudentPageViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }
    }
}
