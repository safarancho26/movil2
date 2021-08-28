using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CrudMVVM.Datas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(CrudMVVM.Droid.Connection.SQLiteConnection))]
namespace CrudMVVM.Droid.Connection
{
    class SQLiteConnection : IDataBase
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "empleado.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}