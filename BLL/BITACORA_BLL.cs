using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using SEC;

namespace BLL
{
    public class BITACORA_BLL
    {
        MP_BITACORA gestorbitacora = new MP_BITACORA();

        public void RegistrarEvento(int? idUsuario, string nombreUsuario, string modulo, string accion, string criticidad)
        {
            BE.BITACORA nuevoregistro = new BE.BITACORA()
            {
                IdUsuario = idUsuario,
                NombreUsuario = nombreUsuario,
                Modulo = modulo,
                Accion = accion,
                Criticidad = criticidad
            };

            gestorbitacora.Insertar(nuevoregistro);
            
        }

        public List<BE.BITACORA> ObtenerRegistros(BE.BITACORA objFiltros, DateTime? desde = null, DateTime? hasta = null)
        {
            
            return gestorbitacora.ListarFiltrado(objFiltros, desde, hasta);
        }
    }
}
