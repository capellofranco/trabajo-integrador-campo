using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_USUARIO : MAPPER<BE.USUARIO>
    {
        public override int Eliminar(USUARIO obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(USUARIO obj)
        {
            throw new NotImplementedException();
        }

        public override List<USUARIO> Listar()
        {
            throw new NotImplementedException();
        }

        public override int Modificar(USUARIO obj)
        {
            throw new NotImplementedException();
        }

        public USUARIO ObtenerUsuarioPorNombre(string nombre)
        {
            acceso = new ACCESO();
            acceso.Conectar();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nom", nombre));

            DataTable tabla = acceso.Leer("ObtenerUsuPorNom", parametros);
            acceso.Desconectar();

            if(tabla.Rows.Count == 0)
            {
                return null;
            }

            DataRow fila = tabla.Rows[0];

            USUARIO usuario = new USUARIO();
            usuario.ID = ;
        }
    }
}