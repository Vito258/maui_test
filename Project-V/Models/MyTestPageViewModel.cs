using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_V.Views.Pages;
using System.Collections.ObjectModel;

namespace Project_V.Models
{
    public class MyTestPageViewModel : ObservableObject
    {
        ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get => students ??= new ObservableCollection<Student>();
            set => SetProperty(ref students, value);
        }

        public MyTestPageViewModel()
        {
            InitializeCollectionCommand = new AsyncRelayCommand(InitializeCollection);
            SelectedNoteCommand = new AsyncRelayCommand<Student>(SelectedNote);
            NewNoteCommand = new AsyncRelayCommand(NewNote);
        }

        async Task InitializeCollection()
        {
            Students.Clear();
            foreach (Student note in await App.DataBase.GetItemsAsync())
            {
                Students.Add(note);
            }
        }

        public IAsyncRelayCommand InitializeCollectionCommand { get; private set; }

        async Task SelectedNote(Student note)
        {
            if (note is not null)
            {
                var parameter = new Dictionary<string, object>()
                {
                    {"load",note }
                };
                await Shell.Current.GoToAsync($"{nameof(StudentPage)}", parameter);
            }

        }

        public IAsyncRelayCommand SelectedNoteCommand { get; private set; }

        async Task NewNote()
        {
            string name = "new";
            await Shell.Current.GoToAsync($"{nameof(StudentPage)}?name={name}");
        }

        public IAsyncRelayCommand NewNoteCommand { get; private set; }

    }
}
