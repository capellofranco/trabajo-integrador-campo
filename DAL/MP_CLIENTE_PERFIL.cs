using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_CLIENTE_PERFIL : MAPPER<BE.CLIENTE_PERFIL>
    {
        ACCESO acceso = new ACCESO();
        public override int Eliminar(CLIENTE_PERFIL obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(CLIENTE_PERFIL obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario",      obj.IdUsuario),
                acceso.CrearParametro("@NombreCompleto", obj.NombreCompleto),
                acceso.CrearParametro("@DNI",            obj.DNI),
                acceso.CrearParametro("@Telefono",       obj.Telefono ?? ""),
                acceso.CrearParametro("@Email",          obj.Email ?? "")
            };
            int filas = acceso.Escribir("InsertarClientePerfil", p);
            acceso.Desconectar();
            return filas;
        }

        public BE.CLIENTE_PERFIL ObtenerPorUsuario(int idUsuario)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario)
            };
            DataTable dt = acceso.Leer("ObtenerClientePerfil", p);
            acceso.Desconectar();
            if (dt.Rows.Count == 0) return null;
            DataRow fila = dt.Rows[0];
            return new BE.CLIENTE_PERFIL
            {
                IdUsuario = int.Parse(fila["IdUsuario"].ToString()),
                NombreCompleto = fila["NombreCompleto"].ToString(),
                DNI = fila["DNI"].ToString(),
                Telefono = fila["Telefono"].ToString(),
                Email = fila["Email"].ToString()
            };
        }

        public override List<CLIENTE_PERFIL> Listar()
        {
            throw new NotImplementedException();
        }

        public override int Modificar(CLIENTE_PERFIL obj)
        {
            throw new NotImplementedException();
        }
    }
}