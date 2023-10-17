using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_V.Models
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        string entry = "0";

        public event PropertyChangedEventHandler PropertyChanged;
        public CalculatorViewModel()
        {
         ClearCommand = new Command(
                execute: () =>
                {
            Entry = "0";
            RefreshCanExecutes();
        });

            BackspaceCommand = new Command(
                execute: () =>
                {
            Entry = Entry.Substring(0, Entry.Length - 1);
            if (Entry == "")
            {
                Entry = "0";
            }
            RefreshCanExecutes();
        },
                canExecute: () =>
                {
                    return Entry.Length > 1 || Entry != "0";
                });

            DigitCommand = new Command<string>(
                execute: (string arg) =>
                {
                    Entry += arg;
                    if (Entry.StartsWith("0") && !Entry.StartsWith("0."))
                    {
                        Entry = Entry.Substring(1);
                    }
                    RefreshCanExecutes();
                },
                canExecute: (string arg) =>
                {
                    return !(arg == "." && Entry.Contains("."));
                });
            ResultCommand = new Command<string>(
                execute: (string arg) =>
                {
                    Entry = Compute(arg);
                    RefreshCanExecutes();
                },
                canExecute: (string arg) =>
                {
                    return !(arg == "." && Entry.Contains("."));
                });
        }

            void RefreshCanExecutes()
            {
                ((Command)BackspaceCommand).ChangeCanExecute();
                ((Command)DigitCommand).ChangeCanExecute();
                ((Command)ClearCommand).ChangeCanExecute();
                ((Command)ResultCommand).ChangeCanExecute();
            }

            public string Entry
            {
                private set
                {
                    if (entry != value)
                    {
                        entry = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entry"));
                    }
                }
                get
                {
                    return entry;
                }
            }
            string Compute(string temp)
            {
               string result =  new System.Data.DataTable().Compute(temp, "") as string;
               return result;
            }

            public ICommand ClearCommand { private set; get; }
            
            public ICommand BackspaceCommand { private set; get; }
            
            public ICommand DigitCommand { private set; get; }
            public ICommand ResultCommand { private set; get; }

            public ICommand PlusCommand { private set; get; }
              
       }
}

