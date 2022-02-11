using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace HomeWork2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        private const string url = "https://jsonplaceholder.typicode.com/comments";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Root> _post;
        private LaptopViewModel vm = new LaptopViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var root = JsonConvert.DeserializeObject<List<Root>>(content);
            _post = new ObservableCollection<Root>(root);
            Post_List.ItemsSource = _post;
            base.OnAppearing();

            await vm.ChangeInt();
        }

    }
}
