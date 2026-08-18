using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_PERMISO:MAPPER<BE.PERMISO>
    {
        ACCESO acceso = new ACCESO();

        public override List<BE.PERMISO> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarPermisos", null);
            acceso.Desconectar();
            var lista = new List<BE.PERMISO>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearPermiso(fila));
            return lista;
        }

        public List<BE.PERMISO> ListarPermisosDeRol(int idRol)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdRol", idRol)
            };
            DataTable dt = acceso.Leer("ListarPermisosDeRol", p);
            acceso.Desconectar();
            var lista = new List<BE.PERMISO>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearPermiso(fila));
            return lista;
        }

        public void AgregarPermisoARol(int idRol, int idPermiso)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdRol",     idRol),
                acceso.CrearParametro("@IdPermiso", idPermiso)
            };
            acceso.Escribir("AgregarPermisoARol", p);
            acceso.Desconectar();
        }

        public void QuitarPermisoDeRol(int idRol, int idPermiso)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdRol",     idRol),
                acceso.CrearParametro("@IdPermiso", idPermiso)
            };
            acceso.Escribir("QuitarPermisoDeRol", p);
            acceso.Desconectar();
        }

        public List<BE.PERMISO> ListarPermisosDirectosDeUsuario(int idUsuario)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario)
            };
            DataTable dt = acceso.Leer("ListarPermisosDirectosDeUsuario", p);
            acceso.Desconectar();
            var lista = new List<BE.PERMISO>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearPermiso(fila));
            return lista;
        }

        public void AgregarPermisoAUsuario(int idUsuario, int idPermiso)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario),
                acceso.CrearParametro("@IdPermiso", idPermiso)
            };
            acceso.Escribir("AgregarPermisoAUsuario", p);
            acceso.Desconectar();
        }

        public void QuitarPermisoDeUsuario(int idUsuario, int idPermiso)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdUsuario", idUsuario),
                acceso.CrearParametro("@IdPermiso", idPermiso)
            };
            acceso.Escribir("QuitarPermisoDeUsuario", p);
            acceso.Desconectar();
        }

        private BE.PERMISO MapearPermiso(DataRow fila)
        {
            return new BE.PERMISO(
                int.Parse(fila["IdPermiso"].ToString()),
                fila["Nombre"].ToString(),
                fila["Descripcion"].ToString()
            );
        }

        public override int Insertar(BE.PERMISO obj) { throw new NotImplementedException(); }
        public override int Modificar(BE.PERMISO obj) { throw new NotImplementedException(); }
        public override int Eliminar(BE.PERMISO obj) { throw new NotImplementedException(); }
    }
}

