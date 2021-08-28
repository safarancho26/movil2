using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudMVVM.Datas
{
    public interface IDataBase
    {
        SQLiteConnection GetConnection(); //conexion con base de datos
       
    }
}
