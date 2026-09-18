using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class PAGO
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public string Estado { get; set; }
    }
}