using SQLite;

namespace CrudMVVM.Models
{
    public class Pagos
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pago { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public string Fecha { get; set; }
        public  byte[]  Photo_Recibo{ get; set; }
        public override string ToString()
        {
            return this.Descripcion + " " + this.Monto + " " + this.Fecha ;
        }
    }
}
