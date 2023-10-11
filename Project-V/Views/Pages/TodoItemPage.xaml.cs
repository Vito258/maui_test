using Project_V.Models;

namespace Project_V.Views.Pages
{
    public partial class TodoItemPage
    {
        TodoItemDatabase database;
        public TodoItemPage(TodoItemDatabase todoItemDatabase)
        {
            InitializeComponent();
            database = todoItemDatabase;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            Student Item = sender as Student;
            if (string.IsNullOrWhiteSpace(Item.Name))
            {
                await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
                return;
            }

            await App.DataBase.SaveItemAsync(Item);
            await Shell.Current.GoToAsync("");     //通过路由路径跳转？
        }
    }
}
