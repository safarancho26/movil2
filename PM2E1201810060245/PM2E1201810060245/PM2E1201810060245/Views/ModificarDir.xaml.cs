using Plugin.Geolocator;
using PM2E1201810060245.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E1201810060245.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarDir : ContentPage
    {
        private double latituds;
        private double longituds;
        private string descrilarga;
        private string descricorta;
        public ModificarDir()
        {
            InitializeComponent();


        }
  

        private async void salvarUbicacion_Clicked(object sender, EventArgs e)
        {




            if (descripLarga.Text != null)
            {
                if (descripCorta.Text != null)
                {
                    Int32 resultado = 0;
                    using (SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB))
                    {
                        var direcciones = new Direcciones()
                        {

                            latitud = Convert.ToDouble(latitudnueva.Text),
                            longitud = Convert.ToDouble(longitudnueva.Text),
                            descriplarga = Convert.ToString(descripLarga.Text),
                            descripcorta = Convert.ToString(descripCorta.Text)



                        };
                        Direcciones ide = new Direcciones();

                        string x = Convert.ToString(id);
                        Double latituds = Convert.ToDouble(latitudnueva.Text);
                        Double longituds = Convert.ToDouble(longitudnueva.Text);
                        string descriplargas = Convert.ToString(descripLarga.Text);
                        string descripcortas = Convert.ToString(descripCorta.Text);
                        SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);

                        var listadirecciones = conexion.Query<Direcciones>($"UPDATE Direcciones SET latitud='" + latitudnueva.Text + "',longitud='" + longitudnueva.Text + "',descriplarga='" + descripLarga.Text + "',descripcorta='" + descripCorta.Text + "' WHERE Id = '" + id.Text + "' ");
                        conexion.Close();



                        if (listadirecciones != null)
                        {

                            DisplayAlert("Mensaje", "La ubicación a sido modificada", "Ok");

                            longitudnueva.Text = "";
                            latitudnueva.Text = "";
                            descripLarga.Text = "";
                            descripCorta.Text = "";
                            await Navigation.PushAsync(new MainPage());
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



        private async void ubicacionSalvadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesGuardados());
        }



        private async void ubicacionesSalvadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesGuardados());
        }


        private void nuevaUbic_Clicked(object sender, EventArgs e)
        {
            longitudnueva.Text = "";
            latitudnueva.Text = "";
            descripLarga.Text = "";
            descripCorta.Text = "";
        }
    }
}