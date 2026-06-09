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
        }
        public void CrearNuevoIdioma(string nombre)
        {
            _mpTraduccion.InsertarIdioma(nombre);
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
        }

    }
}
