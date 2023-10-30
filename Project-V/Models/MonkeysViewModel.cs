using Project_V.Models.Domains;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Project_V.Models
{
    public class MonkeysViewModel : INotifyPropertyChanged
    {
        readonly IList<Monkey> source;

        public ObservableCollection<Monkey> Monkeys { get; private set; }
        public IList<Monkey> EmptyMonkeys { get; private set; }

        public Monkey PreviousMonkey { get; set; }
        public Monkey CurrentMonkey { get; set; }
        public Monkey CurrentItem { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand ItemChangedCommand => new Command<Monkey>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);
        public ICommand FavoriteCommand => new Command<Monkey>(FavoriteMonkey);

        public MonkeysViewModel()
        {
            source = new List<Monkey>();
            CreateMonkeyCollection();

            CurrentItem = Monkeys.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void CreateMonkeyCollection()
        {
            source.Add(new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                ImageUrl = "https://www.ignant.com/wp-content/uploads/2014/07/The_Gif_Connoisseur_01.gif"
            });

            source.Add(new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                ImageUrl = "https://user-images.githubusercontent.com/17372096/274798147-36d5394f-0856-4418-828a-fd14213cd51a.gif"
            });

            source.Add(new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                ImageUrl = "https://user-images.githubusercontent.com/17372096/274798466-7f263c96-cad1-48c9-a207-ac3a23a349a0.gif"
            });

            source.Add(new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                ImageUrl = "https://api.club-off.com/coa/apps_dev/img/walkthrough-03.gif"
            });

            source.Add(new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                ImageUrl = "https://images.squarespace-cdn.com/content/v1/5876be053e00be4f63b6796c/1521585179269-FGHJC4BO3KXIQB489KU2/ke17ZwdGBToddI8pDm48kI1dxkzCdoaQDevnVA9R4g1Zw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZUJFbgE-7XRK3dMEBRBhUpyKi-oUoBVevRLtXFipgGDcIiZgSYdrptGW3-0WE_JDnWAg8j-9wbE7_h7uxkrF2Ds/Renny-600.gif"
            });

            Monkeys = new ObservableCollection<Monkey>(source);
        }

        void FilterItems(string filter)
        {
            var filteredItems = source.Where(monkey => monkey.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var monkey in source)
            {
                if (!filteredItems.Contains(monkey))
                {
                    Monkeys.Remove(monkey);
                }
                else
                {
                    if (!Monkeys.Contains(monkey))
                    {
                        Monkeys.Add(monkey);
                    }
                }
            }
        }

        void ItemChanged(Monkey item)
        {
            PreviousMonkey = CurrentMonkey;
            CurrentMonkey = item;
            OnPropertyChanged("PreviousMonkey");
            OnPropertyChanged("CurrentMonkey");
        }

        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

        void RemoveMonkey(Monkey monkey)
        {
            if (Monkeys.Contains(monkey))
            {
                Monkeys.Remove(monkey);
            }
        }

        void FavoriteMonkey(Monkey monkey)
        {
            monkey.IsFavorite = !monkey.IsFavorite;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
