using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_SERVICIO : MAPPER<BE.SERVICIO>
    {
        ACCESO acceso = new ACCESO();
        public override int Eliminar(SERVICIO obj)
        {
            throw new NotImplementedException();
        }

        public override int Insertar(SERVICIO obj)
        {
            throw new NotImplementedException();
        }

        private List<BE.SERVICIO> MapearLista(DataTable dt)
        {
            var lista = new List<BE.SERVICIO>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(new BE.SERVICIO
                {
                    IdServicio = int.Parse(fila["IdServicio"].ToString()),
                    Nombre = fila["Nombre"].ToString(),
                    Descripcion = fila["Descripcion"].ToString()
                });
            return lista;
        }

        public override List<SERVICIO> Listar()
        {
            acceso.Conectar();
            DataTable dt = acceso.Leer("ListarServicios", null);
            acceso.Desconectar();
            return MapearLista(dt);
        }

        public List<BE.SERVICIO> ListarServiciosDePaquete(int idPaquete)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdPaquete", idPaquete)
            };
            DataTable dt = acceso.Leer("ListarServiciosDePaquete", p);
            acceso.Desconectar();
            return MapearLista(dt);
        }

        public void AgregarServicioAPaquete(int idPaquete, int idServicio)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdPaquete",  idPaquete),
                acceso.CrearParametro("@IdServicio", idServicio)
            };
            acceso.Escribir("AgregarServicioAPaquete", p);
            acceso.Desconectar();
        }

        public void QuitarServicioDePaquete(int idPaquete, int idServicio)
        {
            acceso.Conectar();
            var p = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdPaquete",  idPaquete),
                acceso.CrearParametro("@IdServicio", idServicio)
            };
            acceso.Escribir("QuitarServicioDePaquete", p);
            acceso.Desconectar();
        }



        public override int Modificar(SERVICIO obj)
        {
            throw new NotImplementedException();
        }
    }
}