using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public abstract class ComponenteAcceso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        protected ComponenteAcceso(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}