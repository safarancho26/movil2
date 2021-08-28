using PM2E1201810060245.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PM2E1201810060245.Services
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        Direcciones dir = new Direcciones();



        String _db = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DB.sqlite");
        public SQLiteHelper(string _db)
        {
            db = new SQLiteAsyncConnection(_db);
            db.CreateTableAsync<Direcciones>().Wait();
        }

    }

}