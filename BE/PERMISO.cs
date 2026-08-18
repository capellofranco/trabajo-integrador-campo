using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class PERMISO: ComponenteAcceso
    {
        public int IdPermiso { get; set; }

        public PERMISO(int id, string nombre, string descripcion)
            : base(nombre, descripcion)
        {
            IdPermiso = id;
        }
    }
}