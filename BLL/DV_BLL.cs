using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DV_BLL
    {
        private MP_DV _mpDV = new MP_DV();

        

        private readonly List<string> _columnasUsuario = new List<string>
        {
            "NombreUsuario",
            "IntentosFallidos",
            "Bloqueado"
        };

        public void RecalcularTodo()
        {
            DataTable dt = _mpDV.ObtenerTodosParaDV();

            var valoresPorColumna = new Dictionary<string, List<string>>();
            foreach (var col in _columnasUsuario)
                valoresPorColumna[col] = new List<string>();

            foreach (DataRow fila in dt.Rows)
            {
                var valores = new List<string>
                {
                    fila["NombreUsuario"].ToString(),
                    fila["IntentosFallidos"].ToString(),
                    fila["Bloqueado"].ToString()
                };

                int dvh = SEC.DigitoVerificadores.CalcularDVH(valores);
                int id = int.Parse(fila["ID"].ToString());
                _mpDV.ActualizarDVH(id, dvh);

                foreach (var col in _columnasUsuario)
                    valoresPorColumna[col].Add(fila[col].ToString());
            }

            foreach (var col in _columnasUsuario)
            {
                int dvv = SEC.DigitoVerificadores.CalcularDVV(valoresPorColumna[col]);
                _mpDV.ActualizarDVV("USUARIO", col, dvv);
            }
        }

        public List<string> VerificarIntegridad()
        {
            var errores = new List<string>();
            DataTable dt = _mpDV.ObtenerTodosParaDV();

            var valoresPorColumna = new Dictionary<string, List<string>>();
            foreach (var col in _columnasUsuario)
                valoresPorColumna[col] = new List<string>();

            foreach (DataRow fila in dt.Rows)
            {
                var valores = new List<string>
                {
                    fila["NombreUsuario"].ToString(),
                    fila["IntentosFallidos"].ToString(),
                    fila["Bloqueado"].ToString()
                };

                int dvhCalculado = SEC.DigitoVerificadores.CalcularDVH(valores);
                int dvhGuardado = int.Parse(fila["DVH"].ToString());

                if (dvhCalculado != dvhGuardado)
                    errores.Add($"Error DVH: el usuario '{fila["NombreUsuario"]}' fue modificado fuera del sistema.");

                foreach (var col in _columnasUsuario)
                    valoresPorColumna[col].Add(fila[col].ToString());
            }

            foreach (var col in _columnasUsuario)
            {
                int dvvCalculado = SEC.DigitoVerificadores.CalcularDVV(valoresPorColumna[col]);
                int dvvGuardado = _mpDV.ObtenerDVV("USUARIO", col);

                if (dvvCalculado != dvvGuardado)
                    errores.Add($"Error DVV: la columna '{col}' de USUARIO fue alterada fuera del sistema.");
            }

            return errores;
        }
    }
}