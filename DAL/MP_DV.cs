using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_DV: MAPPER<BE.DIGITO_VERIFICADOR_VERTICAL>
    {
        ACCESO acceso = new ACCESO();

        public override int Insertar(BE.DIGITO_VERIFICADOR_VERTICAL obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@Entidad", obj.Entidad),
                acceso.CrearParametro("@Columna", obj.Columna),
                acceso.CrearParametro("@DVV",     obj.DVV)
            };
            int filas = acceso.Escribir("ActualizarDVV", p);
            acceso.Desconectar();
            return filas;
        }

        public DataTable ObtenerTodosParaDV()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ObtenerTodosLosUsuariosParaDV", null);
            acceso.Desconectar();
            return dt;
        }

        public void ActualizarDVH(int id, int dvh)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id",  id),
                acceso.CrearParametro("@DVH", dvh)
            };
            acceso.Escribir("ActualizarDVH", p);
            acceso.Desconectar();
        }

        public int ObtenerDVV(string entidad, string columna)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@Entidad", entidad),
                acceso.CrearParametro("@Columna", columna)
            };
            DataTable dt = acceso.Leer("ObtenerDVV", p);
            acceso.Desconectar();
            if (dt.Rows.Count == 0) return 0;
            return int.Parse(dt.Rows[0]["DVV"].ToString());
        }

        public void ActualizarDVV(string entidad, string columna, int dvv)
        {
            Insertar(new BE.DIGITO_VERIFICADOR_VERTICAL
            {
                Entidad = entidad,
                Columna = columna,
                DVV = dvv
            });
        }

        public override List<BE.DIGITO_VERIFICADOR_VERTICAL> Listar()
        { throw new NotImplementedException(); }
        public override int Modificar(BE.DIGITO_VERIFICADOR_VERTICAL obj)
        { throw new NotImplementedException(); }
        public override int Eliminar(BE.DIGITO_VERIFICADOR_VERTICAL obj)
        { throw new NotImplementedException(); }
    }
}

 