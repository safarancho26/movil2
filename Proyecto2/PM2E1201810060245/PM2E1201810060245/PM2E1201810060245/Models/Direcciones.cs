using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E1201810060245.Models
{
    class Direcciones
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public double latitud { get; set; }

        public double longitud { get; set; }

        [MaxLength(500)]
        public string descriplarga { get; set; }

        [MaxLength(250)]
        public string descripcorta { get; set; }
        public Byte[] foto_casa { get; set; }
    }
}