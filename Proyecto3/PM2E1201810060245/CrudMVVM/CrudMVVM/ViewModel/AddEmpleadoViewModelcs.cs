using CrudMVVM.Datas;
using CrudMVVM.Models;
using CrudMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudMVVM.ViewModel
{
    class AddEmpleadoViewModelcs : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }
        private double _apellido;
        public double Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                OnPropertyChanged();
            }
        }


        private string _edad;
        public string edad
        {
            get { return _edad; }
            set
            {
                _edad = value;
                OnPropertyChanged();
            }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChanged();
            }
        }
        private string _puesto;
        public string Puesto
        {
            get { return _puesto; }
            set
            {
                _puesto = value;
                OnPropertyChanged();
            }
        }

        private Pagos empleado = new Pagos();
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand TapCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public AddEmpleadoViewModelcs(string photo)
        {


            TapCommand = new Command(() =>
                {

                    string input = photo;
                    byte[] array = Encoding.ASCII.GetBytes(input);
                    Database database = new Database();

                    empleado.Id_pago = Id;
                    empleado.Descripcion = Nombre;
                    empleado.Monto = Apellido;
                    empleado.Fecha = edad;
                    empleado.Photo_Recibo = array;

                    database.Insert(empleado);

                    App.Current.MainPage.DisplayAlert("Guardado...", empleado.Descripcion + " Guardado Exitosamente", "OK");



                }
          );
            BackCommand = new Command(() =>
            {
                new NavigationPage(new EmpleadoPage());
            }
          );
        }

       
    }
}
       
   
