using PM2E1201810060245.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E1201810060245.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionesGuardados : ContentPage
    {
        private int id;
        private double latituds;
        private double longituds;
        private string descrilarga;
        private string descricorta;
        public UbicacionesGuardados()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB);
            connection.CreateTable<Direcciones>();
            var listadirecciones = connection.Table<Direcciones>().ToList();
            ubicacionesGuardadas.ItemsSource = listadirecciones;
            connection.Close();
        }

        private void ubicacionesGuardadas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ubicGuardada = e.SelectedItem as Direcciones;
            if (ubicGuardada != null)
            {
                id = ubicGuardada.Id;
                latituds = ubicGuardada.latitud;
                longituds = ubicGuardada.longitud;
                descrilarga = ubicGuardada.descriplarga;
                descricorta = ubicGuardada.descripcorta;
            }
            DisplayAlert("Aviso", "Se ha seleccionado a la ubicación con Latitud " + latituds + " y Longitud " + longituds, "Ok");
        }

        private void eliminar_Clicked(object sender, EventArgs e)
        {
            string x = Convert.ToString(id);

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            var listadirecciones = conexion.Query<Direcciones>($"Delete FROM Direcciones WHERE Id = '" + x + "' ");
            conexion.Close();

            DisplayAlert("Aviso", "Se ha eliminado a la ubicación con Latitud " + latituds + " y Longitud " + latituds, "Ok");
        }

        private async void vermapa_Clicked(object sender, EventArgs e)
        {
            var irmapa = new irMapa()
            {
                mapaId = id,
                mapalatitud = latituds,
                mapalongitud = longituds,
                mapadescriplarga = descrilarga,
                mapadescripcorta = descricorta
            };
            var vermapa = new VerMapa();
            vermapa.BindingContext = irmapa;
            await Navigation.PushAsync(vermapa);
        }

        private async void modificar_Clicked(object sender, EventArgs e)
        {




            var irmapa = new Direcciones()
            {
                Id = id,
                latitud = latituds,
                longitud = longituds,
                descriplarga = descrilarga,
                descripcorta = descricorta,

            };
            var vermapa = new ModificarDir();
            vermapa.BindingContext = irmapa;
            await Navigation.PushAsync(vermapa);
        }



        private async void btnRestApi_Clicked(object sender, EventArgs e)
        {

           var ID = id.ToString();
            var LAT = latituds.ToString();
            var LONG = longituds.ToString();

            var DC = descricorta.ToString();

            await Navigation.PushAsync(new VerPlaces(LAT,LONG));
        }
    }
}