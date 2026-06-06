using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public static class PERMISOMAP_BLL
    {
        public static readonly Dictionary<string, string> MenuItems =
            new Dictionary<string, string>
            {
                { "VerBitacora",           "bitacoraToolStripMenuItem"   },
                { "VerUsuariosBloqueados", "bloqueadosToolStripMenuItem" },
                { "RegistrarUsuario",      "registrarToolStripMenuItem"  },
                { "GestionarRoles",        "gestionRolesToolStripMenuItem"      },
            };
    }
}