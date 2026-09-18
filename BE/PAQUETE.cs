using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class PAQUETE
    {
        public int IdPaquete { get; set; }
        public string Destino { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
        public int DuracionDias { get; set; }
        public decimal Precio { get; set; }
        public int CuposTotal { get; set; }
        public int CuposDisponibles { get; set; }
        public int Activo { get; set; }
        public List<SERVICIO> Servicios { get; set; }

        public PAQUETE()
        {
            Servicios = new List<SERVICIO>();
        }
    }
}