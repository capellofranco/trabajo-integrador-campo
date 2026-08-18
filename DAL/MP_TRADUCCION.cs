using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_TRADUCCION
    {

        private ACCESO acceso = new ACCESO();

        public Dictionary<string, string> ObtenerTraduccionesPorIdioma(int idIdioma)
        {
            acceso.Conectar();
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(acceso.CrearParametro("@IdIdioma", idIdioma));
            DataTable dt = acceso.Leer("ObtenerTraducciones", p);
            acceso.Desconectar();
            var diccionario = new Dictionary<string, string>();
            foreach (DataRow fila in dt.Rows)
            {
                diccionario.Add(fila["NombreControl"].ToString(), fila["Texto"].ToString());
            }
            return diccionario;
        }

        public void ActualizarIdiomaUsuario(int idUsuario, int idIdioma)
        {
            acceso.Conectar();
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(acceso.CrearParametro("@IdUsuario", idUsuario));
            p.Add(acceso.CrearParametro("@IdIdioma", idIdioma));
            acceso.Escribir("ActualizarIdiomaUsuario", p);
            acceso.Desconectar();
        }

        public List<BE.IDIOMA> ListarIdiomas()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarIdiomas", null);
            acceso.Desconectar();

            List<BE.IDIOMA> lista = new List<BE.IDIOMA>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new BE.IDIOMA
                {
                    IdIdioma = int.Parse(fila["IdIdioma"].ToString()),
                    Nombre = fila["Nombre"].ToString()
                });
            }
            return lista;
        }

        public void GuardarTraduccion(BE.TRADUCCION trad)
        {
            acceso.Conectar();
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(acceso.CrearParametro("@IdIdioma", trad.IdIdioma));
            p.Add(acceso.CrearParametro("@NombreControl", trad.NombreControl));
            p.Add(acceso.CrearParametro("@Texto", trad.Texto));
            acceso.Escribir("GuardarTraduccion", p);
            acceso.Desconectar();
        }

        public void InsertarIdioma(string nombre)
        {
            acceso.Conectar();
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(acceso.CrearParametro("@Nombre", nombre));
            acceso.Escribir("InsertarIdioma", p);
            acceso.Desconectar();
        }

    }
}
