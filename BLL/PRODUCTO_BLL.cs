using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PRODUCTO_BLL
    {
        DAL.MP_PRODUCTO mapper = new DAL.MP_PRODUCTO();
        BITACORA_BLL bitacoraBLL = new BITACORA_BLL();
        private int ObtenerIdUsuarioActual()
        {
            var usuarioActivo = SEC.SESSION_MANAGER.GetInstance.Usuario;
            if (usuarioActivo == null) throw new Exception("No hay sesión activa.");
            return usuarioActivo.Id;
        }

        public void InsertarProducto(BE.PRODUCTO producto)
        {
            var existentes = ListarProductos();
            bool repetido = existentes.Exists(p => p.Nombre.Trim().ToLower() == producto.Nombre.Trim().ToLower());
            if (repetido)
            {
                throw new Exception($"Ya existe un producto registrado con el nombre '{producto.Nombre}'.");
            }
            int idUsuario = ObtenerIdUsuarioActual();
            mapper.InsertarConAuditoria(producto, idUsuario);
            bitacoraBLL.RegistrarEvento(idUsuario, SEC.SESSION_MANAGER.GetInstance.Usuario.Username, "Productos", $"Se dio de alta el producto '{producto.Nombre}'", "INFO");
        }

        public void ModificarPrecio(int idProducto, string nombreProducto, decimal nuevoPrecio)
        {
            int idUsuario = ObtenerIdUsuarioActual();
            mapper.ModificarPrecioConAuditoria(idProducto, nuevoPrecio, idUsuario);
            bitacoraBLL.RegistrarEvento(idUsuario, SEC.SESSION_MANAGER.GetInstance.Usuario.Username, "Productos", $"Cambio de precio en producto '{nombreProducto}' a ${nuevoPrecio}", "WARNING");
        }

        public void EliminarProducto(BE.PRODUCTO producto)
        {
            mapper.Eliminar(producto);
            int idUsuario = ObtenerIdUsuarioActual();
            bitacoraBLL.RegistrarEvento(idUsuario, SEC.SESSION_MANAGER.GetInstance.Usuario.Username, "Productos", $"Se dio de baja el producto '{producto.Nombre}'", "ERROR");
        }

        public List<BE.PRODUCTO> ListarProductos()
        {
            return mapper.Listar();
        }

        public List<BE.HistoricoPrecio> ObtenerHistorico(int idProducto)
        {
            return mapper.ObtenerHistorico(idProducto);
        }
        public void RestaurarPrecio(int idProducto, string nombreProducto, decimal precioAntiguo)
        {
            int idUsuario = ObtenerIdUsuarioActual();
            mapper.ModificarPrecioConAuditoria(idProducto, precioAntiguo, idUsuario);
            bitacoraBLL.RegistrarEvento(idUsuario, SEC.SESSION_MANAGER.GetInstance.Usuario.Username, "Control de Cambios", $"Se restauró el precio del producto '{nombreProducto}' a un valor histórico: ${precioAntiguo}", "WARNING");
        }

    }
}
