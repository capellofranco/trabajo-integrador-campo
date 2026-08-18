using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ACCESO_BLL
    {
        private MP_ROL _mpRol = new MP_ROL();
        private MP_PERMISO _mpPermiso = new MP_PERMISO();
        private BITACORA_BLL _bitacoraBLL = new BITACORA_BLL();

        

        private BE.ROL ConstruirArbolRol(BE.ROL rol, int idUsuario, HashSet<int> visitados)
        {
            if (visitados.Contains(rol.IdRol)) return rol;
            visitados.Add(rol.IdRol);

            var permisos = _mpPermiso.ListarPermisosDeRol(rol.IdRol);
            foreach (var permiso in permisos)
                rol.Hijos.Add(permiso);

            var subRoles = _mpRol.ListarSubRolesDeUsuario(idUsuario, rol.IdRol);
            foreach (var sub in subRoles)
                rol.Hijos.Add(ConstruirArbolRol(sub, idUsuario, visitados)); 

            return rol;
        }

        private void ObtenerPermisosRecursivos(BE.ComponenteAcceso componente, List<string> acumulador)
        {
            if (componente is BE.PERMISO)
            {
                if (!acumulador.Contains(componente.Nombre))
                    acumulador.Add(componente.Nombre);
                return;
            }

            if (componente is BE.ROL rol)
                foreach (var hijo in rol.Hijos)
                    ObtenerPermisosRecursivos(hijo, acumulador); 
        }

        

        public List<BE.ROL> ObtenerArbolDeUsuario(int idUsuario)
        {
            var roles = _mpRol.ListarRolesDeUsuario(idUsuario);
            var resultado = new List<BE.ROL>();
            foreach (var rol in roles)
                resultado.Add(ConstruirArbolRol(rol, idUsuario, new HashSet<int>()));
            return resultado;
        }

        public List<string> ObtenerPermisosDeUsuario(int idUsuario)
        {
            var permisos = new List<string>();

            var arboles = ObtenerArbolDeUsuario(idUsuario);
            foreach (var arbol in arboles)
                ObtenerPermisosRecursivos(arbol, permisos);

            var directos = _mpPermiso.ListarPermisosDirectosDeUsuario(idUsuario);
            foreach (var p in directos)
                if (!permisos.Contains(p.Nombre))
                    permisos.Add(p.Nombre);

            return permisos;
        }

        public bool TienePermiso(int idUsuario, string nombrePermiso)
            => ObtenerPermisosDeUsuario(idUsuario).Contains(nombrePermiso);

        

        public List<BE.ROL> ListarRoles() => _mpRol.Listar();

        public void CrearRol(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre del rol no puede estar vacío.");
            _mpRol.Insertar(new BE.ROL(0, nombre, descripcion));
            RegistrarAuditoria($"Se creó un nuevo rol: {nombre}");
        }

        

        public List<BE.PERMISO> ListarTodosLosPermisos() => _mpPermiso.Listar();

        public void AgregarPermisoARol(int idRol, int idPermiso)
        {
            _mpPermiso.AgregarPermisoARol(idRol, idPermiso);
            RegistrarAuditoria($"Se agregó el permiso '{ObtenerNombrePermiso(idPermiso)}' al rol '{ObtenerNombreRol(idRol)}'");
        }

        public void QuitarPermisoDeRol(int idRol, int idPermiso)
        {
            _mpPermiso.QuitarPermisoDeRol(idRol, idPermiso);
            RegistrarAuditoria($"Se quitó el permiso '{ObtenerNombrePermiso(idPermiso)}' del rol '{ObtenerNombreRol(idRol)}'");
        }

        

        public void AsignarRolAUsuario(int idUsuario, int idRol)
        {
            var actuales = _mpRol.ListarRolesDeUsuario(idUsuario);
            if (actuales.Exists(r => r.IdRol == idRol))
                throw new Exception("El usuario ya tiene ese rol asignado.");
            _mpRol.AsignarRolAUsuario(idUsuario, idRol);
            RegistrarAuditoria($"Se asignó el rol '{ObtenerNombreRol(idRol)}' al usuario '{ObtenerNombreUsuario(idUsuario)}'");
        }

        public void QuitarRolDeUsuario(int idUsuario, int idRol)
        {
            _mpRol.QuitarRolDeUsuario(idUsuario, idRol);
            RegistrarAuditoria($"Se quitó el rol '{ObtenerNombreRol(idRol)}' al usuario '{ObtenerNombreUsuario(idUsuario)}'");
        }

        

        public void AgregarSubRolAUsuario(int idUsuario, int idPadre, int idHijo)
        {
            if (idPadre == idHijo)
                throw new Exception("Un rol no puede contenerse a sí mismo.");
            if (EsDescendienteDeUsuario(idUsuario, idHijo, idPadre, new HashSet<int>()))
                throw new Exception("Operación inválida: generaría una referencia circular.");
            _mpRol.AgregarSubRolAUsuario(idUsuario, idPadre, idHijo);
            RegistrarAuditoria($"Se asignó el sub-rol '{ObtenerNombreRol(idHijo)}' al rol padre '{ObtenerNombreRol(idPadre)}' para el usuario '{ObtenerNombreUsuario(idUsuario)}'");
        }

        public void QuitarSubRolDeUsuario(int idUsuario, int idPadre, int idHijo)
        {
            _mpRol.QuitarSubRolDeUsuario(idUsuario, idPadre, idHijo);
            RegistrarAuditoria($"Se quitó el sub-rol '{ObtenerNombreRol(idHijo)}' del rol padre '{ObtenerNombreRol(idPadre)}' para el usuario '{ObtenerNombreUsuario(idUsuario)}'");
        }

        private bool EsDescendienteDeUsuario(int idUsuario, int idRol, int candidato, HashSet<int> visitados)
        {
            if (visitados.Contains(idRol)) return false;
            visitados.Add(idRol);
            var hijos = _mpRol.ListarSubRolesDeUsuario(idUsuario, idRol);
            foreach (var hijo in hijos)
            {
                if (hijo.IdRol == candidato) return true;
                if (EsDescendienteDeUsuario(idUsuario, hijo.IdRol, candidato, visitados)) return true;
            }
            return false;
        }

        

        public List<BE.PERMISO> ListarPermisosDirectosDeUsuario(int idUsuario)
            => _mpPermiso.ListarPermisosDirectosDeUsuario(idUsuario);

        public void AgregarPermisoAUsuario(int idUsuario, int idPermiso)
        {
            var actuales = _mpPermiso.ListarPermisosDirectosDeUsuario(idUsuario);
            if (actuales.Exists(p => p.IdPermiso == idPermiso))
                throw new Exception("El usuario ya tiene ese permiso asignado directamente.");
            _mpPermiso.AgregarPermisoAUsuario(idUsuario, idPermiso);
            RegistrarAuditoria($"Se otorgó el permiso directo '{ObtenerNombrePermiso(idPermiso)}' al usuario '{ObtenerNombreUsuario(idUsuario)}'");
        }

        public void QuitarPermisoAUsuario(int idUsuario, int idPermiso)
        {
            _mpPermiso.QuitarPermisoDeUsuario(idUsuario, idPermiso);
            RegistrarAuditoria($"Se quitó el permiso directo '{ObtenerNombrePermiso(idPermiso)}' al usuario '{ObtenerNombreUsuario(idUsuario)}'");
        }
        private string ObtenerNombreUsuario(int idUsuario)
        {
            var usuBLL = new USUARIO_BLL();
            var usuario = usuBLL.ListarUsuarios().FirstOrDefault(u => u.Id == idUsuario);
            return usuario != null ? usuario.Username : idUsuario.ToString();
        }

        private string ObtenerNombreRol(int idRol)
        {
            var rol = _mpRol.Listar().FirstOrDefault(r => r.IdRol == idRol);
            return rol != null ? rol.Nombre : idRol.ToString();
        }

        private string ObtenerNombrePermiso(int idPermiso)
        {
            var permiso = _mpPermiso.Listar().FirstOrDefault(p => p.IdPermiso == idPermiso);
            return permiso != null ? permiso.Nombre : idPermiso.ToString();
        }


        private void RegistrarAuditoria(string accionRealizada)
        {
            try
            {
                var usuarioActivo = SEC.SESSION_MANAGER.GetInstance.Usuario;
                if (usuarioActivo != null)
                {
                    _bitacoraBLL.RegistrarEvento(usuarioActivo.Id, usuarioActivo.Username, "Gestión Roles", accionRealizada, "INFO");
                }
            }
            catch
            {
                
            }
        }
    }
}

