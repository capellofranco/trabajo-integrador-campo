using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_PAQUETE : MAPPER<BE.PAQUETE>
    {
        ACCESO acceso = new ACCESO();

        private BE.PAQUETE MapearPaquete(DataRow fila)
        {
            return new BE.PAQUETE
            {
                IdPaquete = int.Parse(fila["IdPaquete"].ToString()),
                Destino = fila["Destino"].ToString(),
                Descripcion = fila["Descripcion"].ToString(),
                FechaSalida = Convert.ToDateTime(fila["FechaSalida"]),
                FechaRegreso = Convert.ToDateTime(fila["FechaRegreso"]),
                DuracionDias = int.Parse(fila["DuracionDias"].ToString()),
                Precio = Convert.ToDecimal(fila["Precio"]),
                CuposTotal = int.Parse(fila["CuposTotal"].ToString()),
                CuposDisponibles = int.Parse(fila["CuposDisponibles"].ToString()),
                Activo = int.Parse(fila["Activo"].ToString())
            };
        }
        public override int Eliminar(PAQUETE obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdPaquete", obj.IdPaquete)
            };
            int filas = acceso.Escribir("EliminarPaquete", p);
            acceso.Desconectar();
            return filas;
        }

        public override int Insertar(PAQUETE obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@Destino",     obj.Destino),
                acceso.CrearParametro("@Descripcion", obj.Descripcion ?? ""),
                new SqlParameter("@FechaSalida",  obj.FechaSalida),
                new SqlParameter("@FechaRegreso", obj.FechaRegreso),
                acceso.CrearParametro("@DuracionDias", obj.DuracionDias),
                new SqlParameter("@Precio", obj.Precio)
                    { DbType = System.Data.DbType.Decimal },
                acceso.CrearParametro("@CuposTotal", obj.CuposTotal)
            };
            DataTable dt = acceso.Leer("InsertarPaquete", p);
            acceso.Desconectar();
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["IdPaquete"].ToString());
            return -1;
        }

        public override List<PAQUETE> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarPaquetes", null);
            acceso.Desconectar();
            var lista = new List<BE.PAQUETE>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearPaquete(fila));
            return lista;
        }

        public override int Modificar(PAQUETE obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdPaquete",   obj.IdPaquete),
                acceso.CrearParametro("@Destino",     obj.Destino),
                acceso.CrearParametro("@Descripcion", obj.Descripcion ?? ""),
                new SqlParameter("@FechaSalida",  obj.FechaSalida),
                new SqlParameter("@FechaRegreso", obj.FechaRegreso),
                acceso.CrearParametro("@DuracionDias", obj.DuracionDias),
                new SqlParameter("@Precio", obj.Precio)
                    { DbType = System.Data.DbType.Decimal },
                acceso.CrearParametro("@CuposTotal", obj.CuposTotal)
            };
            int filas = acceso.Escribir("ModificarPaquete", p);
            acceso.Desconectar();
            return filas;
        }
    }
}