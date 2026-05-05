using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BITACORA
    {
        public int IdBitacora {  get; set; }
        public DateTime FechaHora { get; set; }
        public int? IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Modulo {  get; set; }
        public string Accion {  get; set; }
        public string Criticidad { get; set; }

    }
}
