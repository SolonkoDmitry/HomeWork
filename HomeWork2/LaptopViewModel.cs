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
    public class Root
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }

    public class LaptopViewModel : INotifyPropertyChanged
    {
        private const string url = "https://jsonplaceholder.typicode.com/comments";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Root> _post;
        public event PropertyChangedEventHandler PropertyChanged;
        private Laptop laptop;
        private int _someInt = 123;

        public async Task Output()
        {
            var content = await _Client.GetStringAsync(url);
            var root = JsonConvert.DeserializeObject<List<Root>>(content);
            _post = new ObservableCollection<Root>(root);
            
        }
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

        public LaptopViewModel()
        {
            laptop = new Laptop();
        }



    }
}
