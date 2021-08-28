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
            _sqlconnection.CreateTable<Pagos>();
        }
        public int Insert(Pagos pago)
        {
            lock (locker)
            {
                return _sqlconnection.Insert(pago);
            }
        }
        public int Update(Pagos pago)
        {
            lock (locker)
            {
                return _sqlconnection.Update(pago);
            }
        }
        public int Delete(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Delete<Pagos>(id);
            }
        }
        public IEnumerable<Pagos> GetAll()
        {
            lock (locker)
            {
                return (from i in _sqlconnection.Table<Pagos>() select i).ToList();
            }
        }
        public int FullDelete()
        {
            lock (locker)
            {
                return _sqlconnection.DeleteAll<Pagos>();
            }
        }
        public Pagos Get(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<Pagos>().FirstOrDefault(t => t.Id_pago == id);
            }
        }
        public void Dispose()
        {
            _sqlconnection.Dispose();
        }

       
    }
}
