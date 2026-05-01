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

            return usuario;

        }
    }
}