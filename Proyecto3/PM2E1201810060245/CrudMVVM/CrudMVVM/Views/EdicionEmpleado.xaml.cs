using CrudMVVM.Datas;
using CrudMVVM.Models;
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
    public partial class EdicionEmpleado : ContentPage
    {
        public EdicionEmpleado()
        {

            InitializeComponent();
            this.BindingContext = new EmpleadoViewModel();
            Database database = new Database();
            Pagos empleado = new Pagos();
            listempleado.ItemSelected += selecciontabla;
            resultadosbd.Children.Add(listempleado);
        }
        private void selecciontabla(object sender, SelectedItemChangedEventArgs e)
        {
            Pagos empleado = (Pagos)e.SelectedItem;
            id.Text = empleado.Id_pago.ToString();
            nombre.Text = empleado.Descripcion.ToString();
            apellido.Text = empleado.Monto.ToString();
            if (empleado.Fecha == null)
                edades.Text = DateTime.Today.ToString();
            else
                edades.Text = empleado.Fecha;
          
        }
        private async void edit_Clicked(object sender, EventArgs e)
        {
            Database database = new Database();
            Pagos empleado = new Pagos()
            {
                Id_pago = Convert.ToInt32(id.Text),
                Descripcion = nombre.Text,
                Monto = Convert.ToDouble(apellido.Text),
                Fecha = edades.Text,
                
            };
            database.Update(empleado);
            await Navigation.PopAsync();
            await App.Current.MainPage.DisplayAlert("Modificando...", empleado.Descripcion + " Modificado Exitosamente", "OK");
        }
        private async void delete_Clicked(object sender, EventArgs e)
        {
            Database database = new Database();
            Pagos empleado = new Pagos()
            {
                Id_pago = Convert.ToInt32(id.Text),
                Descripcion = nombre.Text,
                Monto = Convert.ToDouble(apellido.Text),
                Fecha = edades.Text,
               
            };
            database.Delete(empleado.Id_pago);
            await App.Current.MainPage.DisplayAlert("Eliminando...", empleado.Descripcion + " Eliminado Exitosamente", "OK");
            await Navigation.PushAsync(new EmpleadoPage());
        }

      
    }
}