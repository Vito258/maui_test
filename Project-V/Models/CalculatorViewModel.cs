using System.ComponentModel;
using System.Data;
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
                    Entry = EvaluateExpression(arg);
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
        private string EvaluateExpression(string expression)
        {
            // 将算式字符串转换为字符标签序列
            List<int> labels = new List<int>();
            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    labels.Add(int.Parse(c.ToString()));
                }
                else
                {
                    switch (c)
                    {
                        case '+':
                            labels.Add(10);
                            break;
                        case '-':
                            labels.Add(11);
                            break;
                        case '*':
                            labels.Add(12);
                            break;
                        case '/':
                            labels.Add(13);
                            break;
                        case '(':
                            labels.Add(14); break;
                        case ')':
                            labels.Add(15);
                            break;
                    }
                }
            }

            // 使用DataTable类的Compute方法计算标签序列所代表的数学表达式
            string[] operatorsToEval = { "+", "-", "*", "/", "(", ")" };
            string toEval = string.Join("", labels.Select(label =>
            {
                if (0 <= label && label <= 9)
                {
                    return label.ToString();
                }
                return operatorsToEval[label - 10];
            }));
            var evalResult = new DataTable().Compute(toEval, null);

            // 将计算结果格式化为传统的数学写法
            if (evalResult is DBNull)
            {
                return "Error";
            }
            else
            {
                string[] operatorsToDisplay = { "+", "-", "×", "÷", "(", ")" };
                string toDisplay = string.Join("", labels.Select(label =>
                {
                    if (0 <= label && label <= 9)
                    {
                        return label.ToString();
                    }
                    return operatorsToDisplay[label - 10];
                }));
                return $"{toDisplay}={evalResult}";
            }
        }

        public ICommand ClearCommand { private set; get; }

        public ICommand BackspaceCommand { private set; get; }

        public ICommand DigitCommand { private set; get; }
        public ICommand ResultCommand { private set; get; }



    }
}

