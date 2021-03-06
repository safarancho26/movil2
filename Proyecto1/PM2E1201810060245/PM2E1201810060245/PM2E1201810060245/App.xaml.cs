using PM2E1201810060245.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E1201810060245
{
    public partial class App : Application
    {
        public static string UbicacionDB = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(String DBLocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
            UbicacionDB = DBLocal;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}