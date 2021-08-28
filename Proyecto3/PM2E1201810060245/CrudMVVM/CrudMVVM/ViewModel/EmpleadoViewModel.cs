using CrudMVVM.Datas;
using CrudMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Xamarin.Forms;

namespace CrudMVVM.ViewModel
{
    public class EmpleadoViewModel : Pagos
    {
        
        public ICommand editCommand { get; private set; }
        public ICommand deleteCommand { get; private set; }
        private ObservableCollection<Pagos> listem;
        public static Database database = null;
        public static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }
        
        public EmpleadoViewModel()
        {
            Database database = new Database();
            Pagos empleado = new Pagos();

            editCommand = new Command(() =>
            {
                
                empleado.Id_pago = Convert.ToInt32(empleado.Id_pago);
                empleado.Descripcion = empleado.Descripcion;
                empleado.Monto = empleado.Monto;
                empleado.Fecha = empleado.Fecha;
               

                database.Update(empleado);
                App.Current.MainPage.DisplayAlert("Modificando...", empleado.Descripcion + " Modificado Exitosamente", "OK");
            }
            );
            deleteCommand = new Command(() =>
            {

                empleado.Id_pago = Convert.ToInt32(empleado.Id_pago);
                empleado.Descripcion = empleado.Descripcion;
                empleado.Monto = empleado.Monto;
                empleado.Fecha = empleado.Fecha;
                database.Delete(empleado.Id_pago);
                App.Current.MainPage.DisplayAlert("Eliminando...", empleado.Descripcion + " Eliminado Exitosamente", "OK");
            }
          );


           
        }

        public ObservableCollection<Pagos> listempleado
        {
            get
            {
                if (listem == null)
                {
                    recogida();
                }

                return listem;
            }

            set
            {
                listem = value;
            }
        }
        public void recogida()
        {
            Database database = new Database();
            
            {
                ObservableCollection<Pagos> modelo = new ObservableCollection<Pagos>(database.GetAll());
                listem = modelo;
            }


        }

    }
}

