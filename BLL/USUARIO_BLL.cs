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

        public bool Login(string nom, string pass)
        {
            USUARIO usuario =mapper.Login(nom, pass);

            if(usuario != null)
            {
                SESSION_MANAGER.Login(usuario);
                return true;
            }

            return false;
        }
         public void Logout()
        {
            SESSION_MANAGER.Logout();
        }


    }
}
