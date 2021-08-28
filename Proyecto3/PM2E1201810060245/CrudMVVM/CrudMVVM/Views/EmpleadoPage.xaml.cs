using CrudMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpleadoPage : ContentPage
    {
        public EmpleadoPage()
        {
            InitializeComponent();
            this.BindingContext = new EmpleadoViewModel();
        }
        private async void btn_crear_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
        private async void btn_update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EdicionEmpleado());
        }
    }
}