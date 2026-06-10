using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public static class PERMISOMAP_BLL
    {
        

        public static readonly Dictionary<string, string> ItemsDirectos =
            new Dictionary<string, string>
            {
                { "VerUsuariosBloqueados", "bloqueadosToolStripMenuItem"       },
                { "GestionarRoles",        "gestionRolesToolStripMenuItem"     },
                { "VerProductos",          "productoToolStripMenuItem"         },
                { "GestionarDV",           "digitoVerificadorToolStripMenuItem"},
                { "VerIdiomas",            "gestionIdiomaToolStripMenuItem"    },
            };

       
        public static readonly Dictionary<string, List<(string Permiso, string Texto, string Handler)>> ItemsConPadre =
            new Dictionary<string, List<(string, string, string)>>
            {
                {
                    "bitacoraToolStripMenuItem", new List<(string, string, string)>
                    {
                        ("VerBitacora",  "Bitacora",  "bitacoraToolStripMenuItem1_Click"),
                        ("VerHistorico", "Historico", "historicoToolStripMenuItem_Click")
                    }
                },
                {
                    "registrarToolStripMenuItem", new List<(string, string, string)>
                    {
                        ("RegistrarUsuario", "Usuario", "usuarioToolStripMenuItem_Click"),
                        ("GestionProductos", "Producto","productoToolStripMenuItem1_Click")
                    }
                }
            };
    }
}