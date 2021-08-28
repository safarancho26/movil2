using CrudMVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CrudMVVM.Datas
{
    public class Database
    {
        static object locker = new object();

        SQLiteConnection _sqlconnection;

        public Database()
        {
            _sqlconnection = DependencyService.Get<IDataBase>().GetConnection();
            _sqlconnection.CreateTable<Empleado>();
        }
        public int Insert(Empleado empleado)
        {
            lock (locker)
            {
                return _sqlconnection.Insert(empleado);
            }
        }
        public int Update(Empleado empleado)
        {
            lock (locker)
            {
                return _sqlconnection.Update(empleado);
            }
        }
        public int Delete(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Delete<Empleado>(id);
            }
        }
        public IEnumerable<Empleado> GetAll()
        {
            lock (locker)
            {
                return (from i in _sqlconnection.Table<Empleado>() select i).ToList();
            }
        }
        public int FullDelete()
        {
            lock (locker)
            {
                return _sqlconnection.DeleteAll<Empleado>();
            }
        }
        public Empleado Get(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<Empleado>().FirstOrDefault(t => t.Id == id);
            }
        }
        public void Dispose()
        {
            _sqlconnection.Dispose();
        }
    }
}
