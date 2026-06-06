using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_USUARIO : MAPPER<BE.USUARIO>
    {
        ACCESO acceso = new ACCESO();
        public override int Eliminar(USUARIO obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(USUARIO obj)
        {
            acceso.Conectar();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@NombreUsuario", obj.Username));
            parametros.Add(acceso.CrearParametro("@Password", obj.Password));
            int filas = acceso.Escribir("RegistrarUsuario", parametros);
            acceso.Desconectar();
            return filas;
        }

        public override List<USUARIO> Listar()
        {
            throw new NotImplementedException();
        }

        public override int Modificar(USUARIO obj)
        {
            throw new NotImplementedException();
        }

        public USUARIO Login(string nombre)
        {
            acceso = new ACCESO();
            acceso.Conectar();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@NombreUsuario", nombre));
  

            DataTable tabla = acceso.Leer("Login", parametros);
            acceso.Desconectar();

            if(tabla.Rows.Count == 0)
            {
                return null;
            }

            DataRow fila = tabla.Rows[0];

            USUARIO usuario = new USUARIO();
            usuario.Id = int.Parse(fila["ID"].ToString());
            usuario.Username = fila["NombreUsuario"].ToString();
            usuario.Password = fila["Password"].ToString();
            usuario.IntentosFallidos = int.Parse(fila["IntentosFallidos"].ToString());
            usuario.Bloqueado = int.Parse(fila["Bloqueado"].ToString());

            return usuario;

        }


        public void IncrementarIntentosFallidos(string nombreUsuario)
        {
            acceso.Conectar();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@NombreUsuario", nombreUsuario));
            acceso.Escribir("IncrementarIntentosFallidos", parametros);
            acceso.Desconectar();
        }

        public void ResetearIntentos(string nombreUsuario)
        {
            acceso.Conectar();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@NombreUsuario", nombreUsuario));
            acceso.Escribir("ResetearIntentos", parametros);
            acceso.Desconectar();
        }

        public void Desbloquear(string nombreUsuario)
        {
            acceso.Conectar();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@NombreUsuario", nombreUsuario));
            acceso.Escribir("DesbloquearUsuario", parametros);
            acceso.Desconectar();
        }

        public List<USUARIO> ListarBloqueados()
        {
            acceso.Conectar();
            DataTable tabla = acceso.Leer("ListarUsuariosBloqueados", null);
            acceso.Desconectar();

            List<USUARIO> lista = new List<USUARIO>();
            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new USUARIO
                {
                    Id = int.Parse(fila["ID"].ToString()),
                    Username = fila["NombreUsuario"].ToString(),
                    IntentosFallidos = int.Parse(fila["IntentosFallidos"].ToString()),
                    Bloqueado = int.Parse(fila["Bloqueado"].ToString())
                });
            }
            return lista;
        }

        public List<BE.USUARIO> ListarTodos()
        {
            acceso.Conectar();
            DataTable tabla = acceso.Leer("ListarUsuarios", null);
            acceso.Desconectar();
            var lista = new List<BE.USUARIO>();
            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new BE.USUARIO
                {
                    Id = int.Parse(fila["ID"].ToString()),
                    Username = fila["NombreUsuario"].ToString()
                });
            }
            return lista;
        }
    }
}