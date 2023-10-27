using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_V.Models
{
    public class MyBindingModel : INotifyPropertyChanged
    {
        internal static MyBindingModel NewInstance()
        {
            var viewModel = new MyBindingModel();
            return viewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string text;
        Color color;


        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
                }
            }
        }

    }
}
