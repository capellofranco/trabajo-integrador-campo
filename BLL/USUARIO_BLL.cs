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

            USUARIO usuario = mapper.Login(nom);

            
            if (usuario == null)
            {
                bitacoraBLL.RegistrarEvento(null, nom, "Seguridad","Intento de login: usuario inexistente", "WARNING");
                return false;
            }

            
            if (usuario.Bloqueado == 1)
            {
                bitacoraBLL.RegistrarEvento(usuario.Id, usuario.Username, "Seguridad","Intento de login: usuario bloqueado", "ERROR");
                return false;
            }

            bool passCorrecta = HashHelper.VerificarHash(pass, usuario.Password);

            if (passCorrecta)
            {
                mapper.ResetearIntentos(nom);
                SESSION_MANAGER.Login(usuario);
                var accesoBLL = new ACCESO_BLL();
                var permisos = accesoBLL.ObtenerPermisosDeUsuario(usuario.Id);
                SESSION_MANAGER.GetInstance.CargarPermisos(permisos);
                bitacoraBLL.RegistrarEvento(usuario.Id, usuario.Username, "Seguridad","Login exitoso", "INFO");
                
                return true;
            }
            else
            {
                mapper.IncrementarIntentosFallidos(nom);

                
                USUARIO usuarioActualizado = mapper.Login(nom);
                int intentos = int.Parse(usuarioActualizado.IntentosFallidos.ToString());
                bool recienBloqueado = usuarioActualizado.Bloqueado == 1;

                if (recienBloqueado)
                {
                    bitacoraBLL.RegistrarEvento(usuario.Id, usuario.Username, "Seguridad",$"Usuario BLOQUEADO tras {intentos} intentos fallidos", "ERROR");
                }
                else
                {
                    bitacoraBLL.RegistrarEvento(usuario.Id, usuario.Username, "Seguridad",$"Contraseña incorrecta (intento {intentos}/3)", "WARNING");
                }
                RecalcularDV();
                return false;
            }
            
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
            RecalcularDV();
            return resultado;
        }

        public void DesbloquearUsuario(string nombreUsuario)
        {
            mapper.Desbloquear(nombreUsuario);
            var admin = SESSION_MANAGER.GetInstance.Usuario;
            bitacoraBLL.RegistrarEvento(admin.Id, admin.Username, "Seguridad",$"Admin desbloqueó al usuario: {nombreUsuario}", "INFO");
            RecalcularDV();
        }

        public List<USUARIO> ObtenerUsuariosBloqueados()
        {
            return mapper.ListarBloqueados();
        }

        public List<USUARIO> ListarUsuarios()
        {
            return mapper.ListarTodos();
        }

        public bool UsuarioTienePermiso(string nombrePermiso)
        {
            return SEC.SESSION_MANAGER.GetInstance.TienePermiso(nombrePermiso);
        }

        private void RecalcularDV()
        {
            new DV_BLL().RecalcularTodo();
        }

        public bool EsAdministrador()
        {
            var accesoBLL = new ACCESO_BLL();
            return accesoBLL.TienePermiso(SESSION_MANAGER.GetInstance.Usuario.Id, "GestionarRoles");
        }

        public List<string> ObtenerPermisosUsuarioActual()
        {
            return new List<string>(SESSION_MANAGER.GetInstance.Permisos);
        }
        public int ObtenerIdUsuarioActivo()
        {
            if (SEC.SESSION_MANAGER.GetInstance.Usuario != null)
            {
                return SEC.SESSION_MANAGER.GetInstance.Usuario.Id;
            }
            throw new Exception("No hay un usuario logueado en la sesión.");
        }
        public int ObtenerIdActivo()
        {
            return SEC.SESSION_MANAGER.GetInstance.Usuario.Id;
        }
        public BE.USUARIO ObtenerUsuarioSesion()
        {
            if (SEC.SESSION_MANAGER.GetInstance.Usuario != null)
            {
                return SEC.SESSION_MANAGER.GetInstance.Usuario;
            }
            return null;
        }
    }
}
