using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class ROL:ComponenteAcceso
    {
        public int IdRol { get; set; }
        public List<ComponenteAcceso> Hijos { get; set; }

        public ROL(int id, string nombre, string descripcion)
            : base(nombre, descripcion)
        {
            IdRol = id;
            Hijos = new List<ComponenteAcceso>();
        }
    }
}