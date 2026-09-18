using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_PAGO : MAPPER<BE.PAGO>
    {
        ACCESO acceso = new ACCESO();
        public override int Eliminar(PAGO obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(PAGO obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdReserva",  obj.IdReserva),
                new SqlParameter("@Monto", obj.Monto)
                    { DbType = System.Data.DbType.Decimal },
                acceso.CrearParametro("@MetodoPago", obj.MetodoPago)
            };
            int filas = acceso.Escribir("InsertarPago", p);
            acceso.Desconectar();
            return filas;
        }

        public void Confirmar(int idPago)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdPago", idPago)
            };
            acceso.Escribir("ConfirmarPago", p);
            acceso.Desconectar();
        }

        public BE.PAGO ObtenerPorReserva(int idReserva)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdReserva", idReserva)
            };
            DataTable dt = acceso.Leer("ObtenerPagoPorReserva", p);
            acceso.Desconectar();
            if (dt.Rows.Count == 0) return null;
            DataRow fila = dt.Rows[0];
            return new BE.PAGO
            {
                IdPago = int.Parse(fila["IdPago"].ToString()),
                IdReserva = int.Parse(fila["IdReserva"].ToString()),
                Monto = Convert.ToDecimal(fila["Monto"]),
                FechaPago = Convert.ToDateTime(fila["FechaPago"]),
                MetodoPago = fila["MetodoPago"].ToString(),
                Estado = fila["Estado"].ToString()
            };
        }

        public override List<PAGO> Listar()
        {
            throw new NotImplementedException();
        }

        public override int Modificar(PAGO obj)
        {
            throw new NotImplementedException();
        }
    }
}