using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_RESERVA : MAPPER<BE.RESERVA>
    {
        ACCESO acceso = new ACCESO();
        public override int Eliminar(RESERVA obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(RESERVA obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario",    obj.IdUsuario),
                acceso.CrearParametro("@IdPaquete",    obj.IdPaquete),
                acceso.CrearParametro("@CantPersonas", obj.CantPersonas),
                new SqlParameter("@ImporteTotal", obj.ImporteTotal)
                    { DbType = System.Data.DbType.Decimal }
            };
            DataTable dt = acceso.Leer("InsertarReserva", p);
            acceso.Desconectar();
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["IdReserva"].ToString());
            return -1;
        }

        public void Confirmar(int idReserva)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdReserva", idReserva)
            };
            acceso.Escribir("ConfirmarReserva", p);
            acceso.Desconectar();
        }

        public void Cancelar(int idReserva)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdReserva", idReserva)
            };
            acceso.Escribir("CancelarReserva", p);
            acceso.Desconectar();
        }

        public List<BE.RESERVA> ListarPorUsuario(int idUsuario)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario)
            };
            DataTable dt = acceso.Leer("ListarReservasPorUsuario", p);
            acceso.Desconectar();
            return MapearLista(dt);
        }

        private List<BE.RESERVA> MapearLista(DataTable dt)
        {
            var lista = new List<BE.RESERVA>();
            foreach (DataRow fila in dt.Rows)
            {
                var r = new BE.RESERVA
                {
                    IdReserva = int.Parse(fila["IdReserva"].ToString()),
                    IdUsuario = int.Parse(fila["IdUsuario"].ToString()),
                    IdPaquete = int.Parse(fila["IdPaquete"].ToString()),
                    DestinoPaquete = fila["Destino"].ToString(),
                    FechaReserva = Convert.ToDateTime(fila["FechaReserva"]),
                    CantPersonas = int.Parse(fila["CantPersonas"].ToString()),
                    ImporteTotal = Convert.ToDecimal(fila["ImporteTotal"]),
                    Estado = fila["Estado"].ToString()
                };
                if (fila.Table.Columns.Contains("NombreCompleto"))
                    r.NombreCliente = fila["NombreCompleto"].ToString();
                lista.Add(r);
            }
            return lista;
        }

        public override List<RESERVA> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarTodasLasReservas", null);
            acceso.Desconectar();
            return MapearLista(dt);
        }

        public override int Modificar(RESERVA obj)
        {
            throw new NotImplementedException();
        }
    }
}