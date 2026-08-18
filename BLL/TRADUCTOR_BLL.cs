using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TRADUCTOR_BLL : Subject
    {
        private static TRADUCTOR_BLL _instancia;
        private List<Observer> _observadores = new List<Observer>();
        private Dictionary<string, string> _traduccionesActuales = new Dictionary<string, string>();
        private IDIOMA _idiomaActual;
        private DAL.MP_TRADUCCION _mpTraduccion = new DAL.MP_TRADUCCION();
        public HashSet<string> ControlesDescubiertos = new HashSet<string>();

        private TRADUCTOR_BLL() { }

        public static TRADUCTOR_BLL GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new TRADUCTOR_BLL();
            }
            return _instancia;
        }

        public void Agregar(Observer observer)
        {
            if (!_observadores.Contains(observer))
                _observadores.Add(observer);
        }

        public void Eliminar(Observer observer)
        {
            if (_observadores.Contains(observer))
                _observadores.Remove(observer);
        }

        public void Notify()
        {
            foreach (var obs in _observadores)
            {
                obs.AgregarLenguaje();
            }
        }

        public void CambiarIdioma(IDIOMA nuevoIdioma, int idUsuarioActivo)
        {
            _idiomaActual = nuevoIdioma;
            if (idUsuarioActivo > 0)
            {
                _mpTraduccion.ActualizarIdiomaUsuario(idUsuarioActivo, nuevoIdioma.IdIdioma);
            }
            _traduccionesActuales = _mpTraduccion.ObtenerTraduccionesPorIdioma(nuevoIdioma.IdIdioma);
            RegistrarLog($"El usuario cambió el idioma de la interfaz a: {nuevoIdioma.Nombre}");
            Notify();
        }

        public IDIOMA GetState()
        {
            return _idiomaActual;
        }

        public string Traducir(string nombreControl, string textoOriginal)
        {
            if (!string.IsNullOrEmpty(nombreControl) && nombreControl != "cmbIdiomaGlobal")
            {
                ControlesDescubiertos.Add(nombreControl);
            }

            if (_idiomaActual == null) return textoOriginal;

            string textoLimpio = textoOriginal;
            if (textoLimpio.StartsWith("#"))
            {
                int primerEspacio = textoLimpio.IndexOf(" ");
                if (primerEspacio != -1)
                    textoLimpio = textoLimpio.Substring(primerEspacio + 1);
            }

            if (_traduccionesActuales.ContainsKey(nombreControl))
            {
                return _traduccionesActuales[nombreControl];
            }

            if (_idiomaActual.Nombre.ToLower() == "español")
            {
                return textoLimpio;
            }

            return $"#{_idiomaActual.Nombre} {textoLimpio}";
        }

        public List<IDIOMA> ObtenerIdiomas()
        {
            return _mpTraduccion.ListarIdiomas();
        }

        public void CrearIdiomaYTraduccion(string nombreIdioma, List<TRADUCCION> traducciones)
        {
            _mpTraduccion.InsertarIdioma(nombreIdioma);
            var nuevo = ObtenerIdiomas().Find(i => i.Nombre == nombreIdioma);
            foreach (var t in traducciones)
            {
                t.IdIdioma = nuevo.IdIdioma;
                _mpTraduccion.GuardarTraduccion(t);
            }
            RegistrarLog($"Se creó el idioma '{nombreIdioma}' junto con un lote de {traducciones.Count} traducciones iniciales");
        }
        public void CrearNuevoIdioma(string nombre)
        {
            _mpTraduccion.InsertarIdioma(nombre);
            RegistrarLog($"Se creó el nuevo idioma en el sistema: {nombre}");
        }

        public Dictionary<string, string> ObtenerTraduccionesDelIdioma(int idIdioma)
        {
            return _mpTraduccion.ObtenerTraduccionesPorIdioma(idIdioma);
        }

        public void GuardarTraducciones(List<TRADUCCION> traducciones)
        {
            foreach (var t in traducciones)
            {
                _mpTraduccion.GuardarTraduccion(t);
            }
            RegistrarLog($"Se actualizaron/guardaron {traducciones.Count} traducciones en la base de datos");
        }
        private void RegistrarLog(string accion, string criticidad = "INFO")
        {
            try
            {
                USUARIO_BLL usuBll = new USUARIO_BLL();
                var usuarioActivo = usuBll.ObtenerUsuarioSesion();
                int? idUsu = usuarioActivo != null ? usuarioActivo.Id : (int?)null;
                string nombreUsu = usuarioActivo != null ? usuarioActivo.Username : "Sistema";
                BITACORA_BLL bitacoraBll = new BITACORA_BLL();
                bitacoraBll.RegistrarEvento(idUsu, nombreUsu, "Gestión de Idiomas", accion, criticidad);
            }
            catch
            {
                
            }
        }

    }
}
