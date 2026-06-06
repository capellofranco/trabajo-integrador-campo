using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_PRODUCTO : MAPPER<BE.PRODUCTO>
    {
        ACCESO acceso = new ACCESO();

        public override int Eliminar(PRODUCTO obj)
        {
            acceso.Conectar();
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(acceso.CrearParametro("@IdProducto", obj.ID));
            int filas = acceso.Escribir("EliminarProducto", p);
            acceso.Desconectar();
            return filas;
        }

        public override int Insertar(PRODUCTO obj)
        {
            throw new NotImplementedException("Se debe usar el método Insertar con IdUsuario");
        }

        public override List<PRODUCTO> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarProductos", null);
            acceso.Desconectar();

            List<BE.PRODUCTO> lista = new List<BE.PRODUCTO>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new BE.PRODUCTO
                {
                    ID = Convert.ToInt32(fila["IdProducto"]),
                    Nombre = fila["Nombre"].ToString(),
                    PrecioActual = Convert.ToDecimal(fila["PrecioActual"]),
                    Activo = true
                });
            }
            return lista;
        }

        public override int Modificar(PRODUCTO obj)
        {
            throw new NotImplementedException();
        }

        public int InsertarConAuditoria(BE.PRODUCTO obj, int idUsuario)
        {
            acceso.Conectar();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Nombre", obj.Nombre));
            SqlParameter paramPrecio = new SqlParameter("@Precio", SqlDbType.Decimal);
            paramPrecio.Value = obj.PrecioActual;
            parametros.Add(paramPrecio);
            parametros.Add(acceso.CrearParametro("@IdUsuario", idUsuario));
            int filas = acceso.Escribir("InsertarProducto", parametros);
            acceso.Desconectar();
            return filas;
        }

        public int ModificarPrecioConAuditoria(int idProducto, decimal nuevoPrecio, int idUsuario)
        {
            acceso.Conectar();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@IdProducto", idProducto));
            SqlParameter paramPrecio = new SqlParameter("@NuevoPrecio", SqlDbType.Decimal);
            paramPrecio.Value = nuevoPrecio;
            parametros.Add(paramPrecio);
            parametros.Add(acceso.CrearParametro("@IdUsuario", idUsuario));
            int filas = acceso.Escribir("ModificarPrecioProducto", parametros);
            acceso.Desconectar();
            return filas;
        }

        public List<BE.HistoricoPrecio> ObtenerHistorico(int idProducto)
        {
            acceso.Conectar();
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(acceso.CrearParametro("@IdProducto", idProducto));
            DataTable dt = acceso.Leer("ObtenerHistoricoProducto", p);
            acceso.Desconectar();
            List<BE.HistoricoPrecio> lista = new List<BE.HistoricoPrecio>();
            MP_USUARIO mpUsuario = new MP_USUARIO();
            var usuarios = mpUsuario.ListarTodos();

            foreach (DataRow fila in dt.Rows)
            {
                var historico = new BE.HistoricoPrecio
                {
                    ID = Convert.ToInt32(fila["IdHistorico"]),
                    IdProducto = Convert.ToInt32(fila["IdProducto"]),
                    Precio = Convert.ToDecimal(fila["Precio"]),
                    FechaModificacion = Convert.ToDateTime(fila["FechaModificacion"])
                };

                if (fila["IdUsuario"] != DBNull.Value)
                {
                    historico.IdUsuario = Convert.ToInt32(fila["IdUsuario"]);
                    var usu = usuarios.Find(u => u.Id == historico.IdUsuario);
                    historico.NombreUsuario = usu != null ? usu.Username : "Desconocido";
                }

                lista.Add(historico);
            }
            return lista;
        }
    }
}
