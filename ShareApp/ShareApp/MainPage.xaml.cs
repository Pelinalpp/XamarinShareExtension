using ShareApp.Helper;
using ShareApp.Models;
using ShareApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel MainPageVM { get; set; }
        public MainPage()
        {
            InitializeComponent();

            if(MainPageVM == null)
                MainPageVM = new MainPageViewModel();

            BindingContext = MainPageVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MainPageVM.ItemList = Datas.SharedItems;
        }
    }
}
