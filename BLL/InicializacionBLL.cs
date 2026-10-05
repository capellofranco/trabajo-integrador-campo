using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class InicializacionBLL
    {
        public static void PrepararBaseDeDatos()
        {
            string servidor = DAL.ServidorSql.Detectar();
            DAL.DbInicializador.AsegurarBaseDeDatos(servidor, "TrabajoIntegrador");
        }
    }
}
