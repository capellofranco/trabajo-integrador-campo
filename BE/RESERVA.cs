using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class RESERVA
    {
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdPaquete { get; set; }
        public string DestinoPaquete { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantPersonas { get; set; }
        public decimal ImporteTotal { get; set; }
        public string Estado { get; set; }
    }
}