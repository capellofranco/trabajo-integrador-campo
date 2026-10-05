using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_SOLICITUD : MAPPER<BE.SOLICITUD>
    {
        ACCESO acceso = new ACCESO();

        public override int Eliminar(SOLICITUD obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(SOLICITUD obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario",   obj.IdUsuario),
                acceso.CrearParametro("@Tipo",        obj.Tipo),
                acceso.CrearParametro("@Descripcion", obj.Descripcion)
            };

            SqlParameter pIdReserva = new SqlParameter("@IdReserva",
                obj.IdReserva.HasValue ? (object)obj.IdReserva.Value : DBNull.Value);
            p.Add(pIdReserva);

            DataTable dt = acceso.Leer("InsertarSolicitud", p);
            acceso.Desconectar();
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["IdSolicitud"].ToString());
            return -1;
        }

        public List<BE.SOLICITUD> ListarPorUsuario(int idUsuario)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario)
            };
            DataTable dt = acceso.Leer("ListarSolicitudesPorUsuario", p);
            acceso.Desconectar();
            return MapearLista(dt);
        }

        public override List<SOLICITUD> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarTodasLasSolicitudes", null);
            acceso.Desconectar();
            return MapearLista(dt);
        }

        public void AsignarEmpleado(int idSolicitud, int idEmpleado)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdSolicitud", idSolicitud),
                acceso.CrearParametro("@IdEmpleado",  idEmpleado)
            };
            acceso.Escribir("AsignarEmpleadoASolicitud", p);
            acceso.Desconectar();
        }

        public void Responder(int idSolicitud, string respuesta)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdSolicitud", idSolicitud),
                acceso.CrearParametro("@Respuesta",   respuesta)
            };
            acceso.Escribir("ResponderSolicitud", p);
            acceso.Desconectar();
        }

        public void Cerrar(int idSolicitud, bool devolucionPago)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdSolicitud",   idSolicitud),
                acceso.CrearParametro("@DevolucionPago", devolucionPago ? 1 : 0)
            };
            acceso.Escribir("CerrarSolicitud", p);
            acceso.Desconectar();
        }

        public BE.SOLICITUD ObtenerPorId(int idSolicitud)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdSolicitud", idSolicitud)
            };
            DataTable dt = acceso.Leer("ObtenerSolicitud", p);
            acceso.Desconectar();
            if (dt.Rows.Count == 0) return null;
            return MapearFila(dt.Rows[0]);
        }

        private List<BE.SOLICITUD> MapearLista(DataTable dt)
        {
            var lista = new List<BE.SOLICITUD>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearFila(fila));
            return lista;
        }

        private BE.SOLICITUD MapearFila(DataRow fila)
        {
            var s = new BE.SOLICITUD
            {
                IdSolicitud = int.Parse(fila["IdSolicitud"].ToString()),
                IdUsuario = int.Parse(fila["IdUsuario"].ToString()),
                Tipo = fila["Tipo"].ToString(),
                Descripcion = fila["Descripcion"].ToString(),
                Estado = fila["Estado"].ToString(),
                FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"]),
                Respuesta = fila["Respuesta"].ToString(),
                DevolucionPago = fila["DevolucionPago"] != DBNull.Value &&
                                 Convert.ToBoolean(fila["DevolucionPago"])
            };

            if (fila["IdReserva"] != DBNull.Value)
                s.IdReserva = int.Parse(fila["IdReserva"].ToString());

            if (fila["IdEmpleado"] != DBNull.Value)
                s.IdEmpleado = int.Parse(fila["IdEmpleado"].ToString());

            if (fila["FechaResolucion"] != DBNull.Value)
                s.FechaResolucion = Convert.ToDateTime(fila["FechaResolucion"]);

            if (fila.Table.Columns.Contains("NombreCliente"))
                s.NombreCliente = fila["NombreCliente"].ToString();

            if (fila.Table.Columns.Contains("DestinoPaquete"))
                s.DestinoPaquete = fila["DestinoPaquete"].ToString();

            return s;
        }

        public void CancelarSolicitud(int idSolicitud)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdSolicitud", idSolicitud)
            };
            acceso.Escribir("CancelarSolicitud", p);
            acceso.Desconectar();
        }
        public override int Modificar(SOLICITUD obj)
        {
            throw new NotImplementedException();
        }
    }
}