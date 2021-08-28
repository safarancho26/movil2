using CrudMVVM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EmpleadoPage());

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
