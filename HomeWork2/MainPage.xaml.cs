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
    
    public partial class MainPage : ContentPage
    {
        private LaptopViewModel vm = new LaptopViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {

            base.OnAppearing();

            await vm.ChangeInt();
        }

    }
}
