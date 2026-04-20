using BE;
using DAL;
using SEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class USUARIO_BLL
    {
        MP_USUARIO mapper = new MP_USUARIO();
        BITACORA_BLL bitacoraBLL = new BITACORA_BLL();


        public bool Login(string nom, string pass)
        {
            string passwordHasheada = HashHelper.GenerarHash(pass);
            USUARIO usuario =mapper.Login(nom, passwordHasheada);

            if(usuario != null)
            {
                SESSION_MANAGER.Login(usuario);
                bitacoraBLL.RegistrarEvento(usuario.Id, usuario.Username, "Seguridad", "Login Exitoso", "INFO");
                return true;
            }
            bitacoraBLL.RegistrarEvento(null, nom, "Seguridad", "Intento de login fallido", "WARNING");
            return false;
        }
        public void Logout()
        {
            var usuarioActual = SESSION_MANAGER.GetInstance.Usuario;
            bitacoraBLL.RegistrarEvento(usuarioActual.Id, usuarioActual.Username, "Seguridad", "Cierre de sesión", "INFO");
            SESSION_MANAGER.Logout();
        }

        public int RegistrarUsuario(USUARIO nuevoUsuario)
        {
            nuevoUsuario.Password = HashHelper.GenerarHash(nuevoUsuario.Password);
            int resultado = mapper.Insertar(nuevoUsuario);
            if(resultado > 0)
            {
                var usuarioLogueado = SESSION_MANAGER.GetInstance.Usuario;
                bitacoraBLL.RegistrarEvento(usuarioLogueado.Id, usuarioLogueado.Username, "Usuarios", $"Se registró al usuario: {nuevoUsuario.Username}", "INFO");
            }

            return resultado;
        }

    }
}
