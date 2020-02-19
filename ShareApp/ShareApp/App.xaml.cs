using ShareApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShareApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            if (Application.Current.MainPage.BindingContext is IAppStateAware appStateAwareVm)
                appStateAwareVm.OnResumeApplicationAsync();
        }
    }
}
