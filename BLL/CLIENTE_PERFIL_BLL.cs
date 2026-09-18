using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CLIENTE_PERFIL_BLL
    {
        private MP_CLIENTE_PERFIL _mapper = new MP_CLIENTE_PERFIL();
        private BITACORA_BLL _bitacora = new BITACORA_BLL();

        public BE.CLIENTE_PERFIL ObtenerPerfil(int idUsuario)
            => _mapper.ObtenerPorUsuario(idUsuario);

        public void CrearPerfil(BE.CLIENTE_PERFIL perfil)
        {
            if (string.IsNullOrWhiteSpace(perfil.NombreCompleto))
                throw new Exception("El nombre completo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(perfil.DNI))
                throw new Exception("El DNI no puede estar vacío.");

            _mapper.Insertar(perfil);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Clientes", $"Se completó el perfil del cliente con DNI: {perfil.DNI}", "INFO");
        }

    }
}