using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SEC
{
    public class SESSION_MANAGER
    {
        private static object _lock = new object();
        private static SESSION_MANAGER instancia;

        private USUARIO usuario;

        public USUARIO Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private SESSION_MANAGER()
        {

        }

        public static SESSION_MANAGER GetInstance
        {
            get
            {
                if (instancia == null)
                {
                    throw new Exception("Sesion no iniciada");
                }

                return instancia;
            }
        }

        public static void Login(USUARIO usu)
        {
            lock (_lock)
            {

                if(instancia == null)
                {
                    instancia = new SESSION_MANAGER();
                    instancia.usuario = usu;
                    instancia.fechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("Sesion ya iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock (_lock)
            {
                if(instancia != null)
                {
                    instancia = null;
                }
                else
                {
                    throw new Exception("Sesion no iniciada");
                }
            }
        }







    }
}
