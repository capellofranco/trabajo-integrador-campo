using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
using System.Data;

namespace DAL
{
    public class MP_BITACORA : MAPPER<BE.BITACORA>
    {
        ACCESO acceso = new ACCESO();

        public override int Eliminar(BITACORA obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(BITACORA obj)
        {
            acceso.Conectar();
            List<SqlParameter> parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@IdUsuario", obj.IdUsuario ?? (object)DBNull.Value));
            parametro.Add(new SqlParameter("@NombreUsuario", string.IsNullOrEmpty(obj.NombreUsuario) ? DBNull.Value : (object)obj.NombreUsuario));
            parametro.Add(acceso.CrearParametro("@Modulo", obj.Modulo));
            parametro.Add(acceso.CrearParametro("@Accion", obj.Accion));
            parametro.Add(acceso.CrearParametro("@Criticidad", obj.Criticidad));
            int fias = acceso.Escribir("InsertarBitacora",parametro);
            acceso.Desconectar();
            return fias;
        }

        public List<BITACORA> ListarFiltrado(BITACORA obj, DateTime? desde = null, DateTime? hasta = null)
        {
            acceso.Conectar();
            List<SqlParameter> parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter("@Desde", desde.HasValue ? (object)desde.Value : DBNull.Value));
            parametro.Add(new SqlParameter("@Hasta", hasta.HasValue ? (object)hasta.Value : DBNull.Value));
            parametro.Add(new SqlParameter("@NombreUsuario", string.IsNullOrEmpty(obj.NombreUsuario) ? DBNull.Value : (object)obj.NombreUsuario));
            parametro.Add(new SqlParameter("@Criticidad", string.IsNullOrEmpty(obj.Criticidad) ? DBNull.Value : (object)obj.Criticidad));
            parametro.Add(new SqlParameter("@Modulo", string.IsNullOrEmpty(obj.Modulo) ? DBNull.Value : (object)obj.Modulo));

            DataTable dt = acceso.Leer("ListarBitacora", parametro);
            acceso.Desconectar();

            List<BE.BITACORA> lista = new List<BITACORA>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new BE.BITACORA
                {
                    IdBitacora = Convert.ToInt32(fila["IdBitacora"]),
                    FechaHora = Convert.ToDateTime(fila["FechaHora"]),
                    IdUsuario = fila["IdUsuario"] != DBNull.Value ? Convert.ToInt32(fila["IdUsuario"]) : (int?)null,
                    NombreUsuario = fila["NombreUsuario"].ToString(),
                    Modulo = fila["Modulo"].ToString(),
                    Accion = fila["Accion"].ToString(),
                    Criticidad = fila["Criticidad"].ToString()
                });
            }
            return lista;
        }

        public override List<BITACORA> Listar()
        {
            return ListarFiltrado(new BE.BITACORA());
        }

        public override int Modificar(BITACORA obj)
        {
            throw new NotImplementedException();
        }
    }
}
