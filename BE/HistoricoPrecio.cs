using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HistoricoPrecio
    {

        public int ID { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int? IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

    }
}
