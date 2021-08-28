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
        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                OnPropertyChanged();
            }
        }
        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _apellido = value;
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

        private Empleado empleado = new Empleado();
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public AddEmpleadoViewModelcs()
        {
        }

        public ICommand TapCommand => new Command(Tap);
        private async void Tap()
        {
            Database database = new Database();
            empleado.Id = Id;
            empleado.Nombre = Nombre;
            empleado.Apellido = Apellido;
            empleado.Direccion = Direccion;
            empleado.Puesto = Puesto;

            database.Insert(empleado);
            await App.Current.MainPage.Navigation.PushModalAsync(new EmpleadoPage());
        }
        public ICommand BackCommand => new Command(Back);
        private async void Back()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
