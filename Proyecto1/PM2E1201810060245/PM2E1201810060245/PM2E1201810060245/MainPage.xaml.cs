using Plugin.Geolocator;
using Plugin.Media.Abstractions;
using PM2E1201810060245.Models;
using PM2E1201810060245.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM2E1201810060245
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TakePhoto.Clicked += TakePhoto_Clicked;
            DisplayAlert("Mensaje", "Debes activar la UBICACION", "Ok");
        }
        private async void ubicacion_Clicked(object sender, EventArgs e)
        {


            var locator = CrossGeolocator.Current;

            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            longitudActual.Text = position.Longitude.ToString();
            latitudActual.Text = position.Latitude.ToString();

        }


        private void salvarUbicacion_Clicked(object sender, EventArgs e)
        {
            string input = txtfoto.ToString();
            byte[] array = Encoding.ASCII.GetBytes(input);


            if (descripLarga.Text != null)
            {
                if (descripCorta.Text != null)
                {
                    Int32 resultado = 0;

                    var direcciones = new Direcciones()
                    {
                        latitud = Convert.ToDouble(latitudActual.Text),
                        longitud = Convert.ToDouble(longitudActual.Text),
                        descriplarga = Convert.ToString(descripLarga.Text),
                        descripcorta = Convert.ToString(descripCorta.Text),
                        foto_casa = array
                    };

                    using (SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB))
                    {
                        connection.CreateTable<Direcciones>();
                        resultado = connection.Insert(direcciones);

                        if (resultado > 0)
                        {
                            DisplayAlert("Mensaje", "La ubicación a sido guardada", "Ok");
                            longitudActual.Text = "";
                            latitudActual.Text = "";
                            descripLarga.Text = "";
                            descripCorta.Text = "";
                        }
                        else
                            DisplayAlert("Mensaje", "Hubo un ERROR", "Ok");
                    }


                }
                else
                {
                    DisplayAlert("Mensaje", "Debe ingresar una Descripción Corta", "Ok");
                }
            }
            else
            {
                DisplayAlert("Mensaje", "Debe ingresar una Descripción Larga", "Ok");
            }

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


        private async void ubicacionSalvadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesGuardados());
        }

        private async void ubicacionesSalvadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesGuardados());
        }


        private async void CierreSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(); 
        }

        private void nuevaUbic_Clicked(object sender, EventArgs e)
        {
            longitudActual.Text = "";
            latitudActual.Text = "";
            descripLarga.Text = "";
            descripCorta.Text = "";
        }
    }
}
