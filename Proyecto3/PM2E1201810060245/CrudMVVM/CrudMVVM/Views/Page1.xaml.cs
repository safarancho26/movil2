using CrudMVVM.ViewModel;
using Plugin.Media.Abstractions;
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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            this.BindingContext = new AddEmpleadoViewModelcs(txtfoto.ToString());
            edad.Text = DateTime.Today.ToString();
         
        }


        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            if (photo != null)
            {
                txtfoto.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmpleadoPage()); 
        }
    }

}