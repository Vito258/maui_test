using Project_V.Models.Domains;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Project_V.Models
{
    internal class P5ViewModel : INotifyPropertyChanged
    {
        readonly IList<P5> source;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<P5> P5s { get; private set; }
        public P5ViewModel()
        {
            source = new List<P5>();
            CreateCollection();

        }
        void CreateCollection()
        {
            source.Add(new P5
            {
                Id = 1,
                Name = "001",
                Source = new Image { Source = "image1.jpg" }
            });
            source.Add(new P5
            {
                Id = 2,
                Name = "002",
                Source = new Image { Source = "image2.jpg" }
            });
            source.Add(new P5
            {
                Id = 3,
                Name = "003",
                Source = new Image { Source = "image3.jpg" }
            });
            source.Add(new P5
            {
                Id = 4,
                Name = "004",
                Source = new Image { Source = "image4.jpg" }
            });
        }
    }
}
