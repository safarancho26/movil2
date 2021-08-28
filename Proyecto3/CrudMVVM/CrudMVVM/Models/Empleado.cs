using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudMVVM.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public String edad { get; set; }
        public String Direccion { get; set; }
        public String Puesto { get; set; }
    }
}
