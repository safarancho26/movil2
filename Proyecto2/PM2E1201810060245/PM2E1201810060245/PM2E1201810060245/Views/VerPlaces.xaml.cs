using PM2E1201810060245.Models;
using PM2E1201810060245.ViewModels;
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
    public partial class VerPlaces : ContentPage
    {
        private int idss;
        private double latitde;
        private double longit;
        private string cos;

        public VerPlaces(string lat, string log)
        {
            InitializeComponent();
  
            latitud.Text =lat.ToString();
            longitud2.Text = log.ToString();
        }
        private async void btnRestApi_Clicked(object sender, EventArgs e)
        {



            var coordenadas = Plugin.Geolocator.CrossGeolocator.Current;



            coordenadas.DesiredAccuracy = 50;
            var posicion = await coordenadas.GetPositionAsync();

            double a = Convert.ToDouble(latitud.Text.ToString());
            double b = Convert.ToDouble(longitud2.Text.ToString());
            Console.WriteLine("esta es la latitud al tocar el boton:" + a);
            Console.WriteLine("esta es la longitud al tocar el boton:" + b);

            list.ItemsSource = await Metodos.getSites(a, b);

            


            #region test
            //var urlfq = Sitios.getUrl(platitud, plongitud);
            //Debug.WriteLine(urlfq);



            //var url = "https://restcountries.eu/rest/v2/region/europe";
            //var urlfq = Sitios.getUrl(14.55, -88.05);



            //using (HttpClient cliente = new HttpClient())
            //{
            // var Respuesta = await cliente.GetAsync(url);



            // if (Respuesta.IsSuccessStatusCode)
            // {
            // var json = Respuesta.Content.ReadAsStringAsync().Result;
            // await DisplayAlert("Respuesta", json, "Ok");
            // var Paises = JsonConvert.DeserializeObject<List<CountriesREst>>(json);
            // }
            //}
            #endregion
        }



        private void UbicacionesCercanas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {



            var lista = e.SelectedItem as irMapa;
            if (lista != null)
            {



                idss = lista.mapaId;
                latitde = lista.mapalatitud;
                longit = lista.mapalongitud;
                cos = lista.mapadescripcorta;
            }

            DisplayAlert("Aviso", "Escogio"+ cos, "Ok");
        }
        private async void vermapa_Clicked(object sender, EventArgs e)
        {
            var irmapa = new irMapa()
            {
                mapaId = idss,
                mapalatitud = latitde,
                mapalongitud = -longit,
                mapadescripcorta = cos
            };
            var vermapa = new VerMapa();
            vermapa.BindingContext = irmapa;
            await Navigation.PushAsync(vermapa);
        }





    }



}
