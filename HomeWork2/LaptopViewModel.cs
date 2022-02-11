using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HomeWork2
{

    public class LaptopViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Laptop laptop;
        private int _someInt = 123;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int SomeInt
        {
            get => _someInt;
            set
            {
                _someInt = value;
                OnPropertyChanged();
            }
        }
        public async Task ChangeInt()
        {
            await Task.Delay(2000);
            int rnd = new Random().Next(100);
            SomeInt = rnd;
        }

        public ICommand SomeCommand => new Command(async value =>
        {
            await ChangeInt();
        });




    }
}
