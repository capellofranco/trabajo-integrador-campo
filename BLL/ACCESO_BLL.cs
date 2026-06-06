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

        // ── Construcción del árbol Composite por usuario ──────────────────

        private BE.ROL ConstruirArbolRol(BE.ROL rol, int idUsuario, HashSet<int> visitados)
        {
            if (visitados.Contains(rol.IdRol)) return rol;
            visitados.Add(rol.IdRol);

            var permisos = _mpPermiso.ListarPermisosDeRol(rol.IdRol);
            foreach (var permiso in permisos)
                rol.Hijos.Add(permiso);

            var subRoles = _mpRol.ListarSubRolesDeUsuario(idUsuario, rol.IdRol);
            foreach (var sub in subRoles)
                rol.Hijos.Add(ConstruirArbolRol(sub, idUsuario, visitados)); // RECURSIVO

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
                    ObtenerPermisosRecursivos(hijo, acumulador); // RECURSIVO
        }

        // ── Consultas públicas ────────────────────────────────────────────

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

        // ── Gestión de Roles ──────────────────────────────────────────────

        public List<BE.ROL> ListarRoles() => _mpRol.Listar();

        public void CrearRol(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre del rol no puede estar vacío.");
            _mpRol.Insertar(new BE.ROL(0, nombre, descripcion));
        }

        // ── Gestión de Permisos en Roles ──────────────────────────────────

        public List<BE.PERMISO> ListarTodosLosPermisos() => _mpPermiso.Listar();

        public void AgregarPermisoARol(int idRol, int idPermiso)
            => _mpPermiso.AgregarPermisoARol(idRol, idPermiso);

        public void QuitarPermisoDeRol(int idRol, int idPermiso)
            => _mpPermiso.QuitarPermisoDeRol(idRol, idPermiso);

        // ── Asignación Usuario ↔ Rol ──────────────────────────────────────

        public void AsignarRolAUsuario(int idUsuario, int idRol)
        {
            var actuales = _mpRol.ListarRolesDeUsuario(idUsuario);
            if (actuales.Exists(r => r.IdRol == idRol))
                throw new Exception("El usuario ya tiene ese rol asignado.");
            _mpRol.AsignarRolAUsuario(idUsuario, idRol);
        }

        public void QuitarRolDeUsuario(int idUsuario, int idRol)
            => _mpRol.QuitarRolDeUsuario(idUsuario, idRol);

        // ── Sub-roles por usuario ─────────────────────────────────────────

        public void AgregarSubRolAUsuario(int idUsuario, int idPadre, int idHijo)
        {
            if (idPadre == idHijo)
                throw new Exception("Un rol no puede contenerse a sí mismo.");
            if (EsDescendienteDeUsuario(idUsuario, idHijo, idPadre, new HashSet<int>()))
                throw new Exception("Operación inválida: generaría una referencia circular.");
            _mpRol.AgregarSubRolAUsuario(idUsuario, idPadre, idHijo);
        }

        public void QuitarSubRolDeUsuario(int idUsuario, int idPadre, int idHijo)
            => _mpRol.QuitarSubRolDeUsuario(idUsuario, idPadre, idHijo);

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

        // ── Permisos directos de usuario ──────────────────────────────────

        public List<BE.PERMISO> ListarPermisosDirectosDeUsuario(int idUsuario)
            => _mpPermiso.ListarPermisosDirectosDeUsuario(idUsuario);

        public void AgregarPermisoAUsuario(int idUsuario, int idPermiso)
        {
            var actuales = _mpPermiso.ListarPermisosDirectosDeUsuario(idUsuario);
            if (actuales.Exists(p => p.IdPermiso == idPermiso))
                throw new Exception("El usuario ya tiene ese permiso asignado directamente.");
            _mpPermiso.AgregarPermisoAUsuario(idUsuario, idPermiso);
        }

        public void QuitarPermisoAUsuario(int idUsuario, int idPermiso)
            => _mpPermiso.QuitarPermisoDeUsuario(idUsuario, idPermiso);
    }
}

