using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public abstract class MAPPER<T>
    {
        internal ACCESO acceso;

        public abstract int Insertar(T obj);
        public abstract int Modificar(T obj);
        public abstract int Eliminar(T obj);
        public abstract List<T> Listar();



    }
}