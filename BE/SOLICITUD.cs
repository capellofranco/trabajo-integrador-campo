using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class SOLICITUD
    {
        public int IdSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public int? IdReserva { get; set; }
        public int? IdEmpleado { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public string Respuesta { get; set; }
        public bool DevolucionPago { get; set; }
        public string NombreCliente { get; set; }
        public string DestinoPaquete { get; set; }
    }
}