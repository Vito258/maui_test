﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_V.Models
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        string name;
        double age;
        string skills;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
        }

        public double Age
        {
            set { SetProperty(ref age, value); }
            get { return age; }
        }

        public string Skills
        {
            set { SetProperty(ref skills, value); }
            get { return skills; }
        }

        public override string ToString()
        {
            return Name + ", age " + Age;
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}