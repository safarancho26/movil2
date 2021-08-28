using CrudMVVM.Datas;
using CrudMVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Xamarin.Forms;

namespace CrudMVVM.ViewModel
{
    class EmpleadoViewModel : INotifyPropertyChanged
    {
        
    
        private static Database database = null;
        private static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private IEnumerable<Empleado> _empleado;

        public IEnumerable<Empleado> Empleados
        {
            get
            {
                return _empleado;
            }

            set
            {
                _empleado = value;
                OnPropertyChanged();
            }
        }
        public EmpleadoViewModel()
        {
            Empleados = GetConnection().GetAll();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

