using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_ROL: MAPPER<BE.ROL>
    {
        ACCESO acceso = new ACCESO();

        public override List<BE.ROL> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarRoles", null);
            acceso.Desconectar();
            var lista = new List<BE.ROL>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearRol(fila));
            return lista;
        }

        public override int Insertar(BE.ROL obj)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@Nombre",      obj.Nombre),
                acceso.CrearParametro("@Descripcion", obj.Descripcion ?? "")
            };
            int filas = acceso.Escribir("InsertarRol", p);
            acceso.Desconectar();
            return filas;
        }

        public List<BE.ROL> ListarRolesDeUsuario(int idUsuario)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario)
            };
            DataTable dt = acceso.Leer("ListarRolesDeUsuario", p);
            acceso.Desconectar();
            var lista = new List<BE.ROL>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearRol(fila));
            return lista;
        }

        public List<BE.ROL> ListarSubRolesDeUsuario(int idUsuario, int idRolPadre)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario",  idUsuario),
                acceso.CrearParametro("@IdRolPadre", idRolPadre)
            };
            DataTable dt = acceso.Leer("ListarSubRolesDeUsuario", p);
            acceso.Desconectar();
            var lista = new List<BE.ROL>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearRol(fila));
            return lista;
        }

        public void AgregarSubRolAUsuario(int idUsuario, int idPadre, int idHijo)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario",  idUsuario),
                acceso.CrearParametro("@IdRolPadre", idPadre),
                acceso.CrearParametro("@IdRolHijo",  idHijo)
            };
            acceso.Escribir("AgregarSubRolAUsuario", p);
            acceso.Desconectar();
        }

        public void QuitarSubRolDeUsuario(int idUsuario, int idPadre, int idHijo)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario",  idUsuario),
                acceso.CrearParametro("@IdRolPadre", idPadre),
                acceso.CrearParametro("@IdRolHijo",  idHijo)
            };
            acceso.Escribir("QuitarSubRolDeUsuario", p);
            acceso.Desconectar();
        }

        public void AsignarRolAUsuario(int idUsuario, int idRol)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario),
                acceso.CrearParametro("@IdRol",     idRol)
            };
            acceso.Escribir("AsignarRolAUsuario", p);
            acceso.Desconectar();
        }

        public void QuitarRolDeUsuario(int idUsuario, int idRol)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario),
                acceso.CrearParametro("@IdRol",     idRol)
            };
            acceso.Escribir("QuitarRolDeUsuario", p);
            acceso.Desconectar();
        }

        private BE.ROL MapearRol(DataRow fila)
        {
            return new BE.ROL(
                int.Parse(fila["IdRol"].ToString()),
                fila["Nombre"].ToString(),
                fila["Descripcion"].ToString()
            );
        }

        public override int Modificar(BE.ROL obj) { throw new NotImplementedException(); }
        public override int Eliminar(BE.ROL obj) { throw new NotImplementedException(); }
    }
}

