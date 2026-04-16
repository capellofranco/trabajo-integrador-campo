using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace DAL
{
    public class ACCESO
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;

        public void Conectar()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "";
            conexion.Open();
        }

        public void Desconectar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }

        public void IniciarTx()
        {
            transaccion = conexion.BeginTransaction();
        }

        public void ConfirmarTx()
        {
            transaccion.Commit();
            transaccion = null;
        }

        public void CancelarTx()
        {
            transaccion.Rollback();
            transaccion = null;
        }

        public SqlCommand CrearComando(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;

            if(transaccion != null)
            {
                cmd.Transaction = transaccion;
            }
            if(parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }

            return cmd;
        }

        public int Escribir(string sql, List<SqlParameter>parametros = null)
        {
            SqlCommand cmd = CrearComando(sql, parametros);
            int filas = 0;
            try
            {
                filas = cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                filas = -1;
            }

            cmd.Parameters.Clear();
            cmd = null;
            return filas;

        }


        public DataTable Leer(string sql, List<SqlParameter>parametros = null)
        {
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = CrearComando(sql, parametros);
            DataTable tabla = new DataTable();
            adap.Fill(tabla);

            return tabla;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.String;
            return p;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = nombre;
            p.Value = valor;
            p.DbType = DbType.Int32;
            return p;
        }



    }
}
