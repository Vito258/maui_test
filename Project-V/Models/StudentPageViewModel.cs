using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Project_V.Models
{
    public class StudentPageViewModel : ObservableObject, IQueryAttributable
    {
        Student student = new Student();
        public StudentPageViewModel()
        {
            AddStudentCommand = new AsyncRelayCommand(AddStudent);
            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                Student local = query["load"] as Student;
                student = local;
                OnRefresh();
            }
            else if (query.ContainsKey("name"))
            {
                var name = query["name"] as string;
                if (name == "new")
                {
                    student = new Student();
                    OnRefresh();
                }
            }
        }

        private void OnRefresh()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Score));
            OnPropertyChanged(nameof(IsDeleted));
            OnPropertyChanged(nameof(IsNewStudent));
        }

        public int Id
        {
            get => student.Id;
            set => SetProperty(student.Id, value, student, (n, v) => n.Id = v);
        }

        public string Name
        {
            get => student.Name;
            set => SetProperty(student.Name, value, student, (n, v) => n.Name = v);
        }

        public Double Score
        {
            get => student.Score;
            set => SetProperty(student.Score, value, student, (n, v) => n.Score = v);
        }

        public bool IsDeleted
        {
            get => student.IsDeleted;
            set => SetProperty(student.IsDeleted, value, student, (n, v) => n.IsDeleted = v);
        }

        public bool IsNewStudent
        {
            get => student.IsNewStudent;
            set => SetProperty(student.IsNewStudent, value, student, (n, v) => n.IsNewStudent = v);
        }

        async Task AddStudent()
        {
            await App.DataBase.SaveItemAsync(student);

        }

        public IAsyncRelayCommand AddStudentCommand { get; private set; }

        async Task DeleteStudent()
        {
            await App.DataBase.DeleteItemAsync(student);
        }

        public IAsyncRelayCommand DeleteStudentCommand { get; private set; }

    }
}
