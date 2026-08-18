using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface Subject
    {
        void Agregar(Observer observer);
        void Eliminar(Observer observer);
        void Notify();
    }
}
