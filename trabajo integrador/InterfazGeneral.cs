using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajo_integrador
{
    public partial class InterfazGeneral : Form
    {
        BLL.USUARIO_BLL gestorusuario = new BLL.USUARIO_BLL();
        public InterfazGeneral()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestorusuario.Logout();
            this.Close();
            Application.Restart();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRegistrar frm = new FRMRegistrar();
            frm.ShowDialog();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMBitacora frm = new FRMBitacora();
            frm.ShowDialog();
        }

        private void InterfazGeneral_Load(object sender, EventArgs e)
        {
            AplicarVisibilidad();
        }

        private void AplicarVisibilidad()
        {
            USUARIO_BLL usuarioBLL = new USUARIO_BLL();

            
            foreach (var entry in PERMISOMAP_BLL.MenuItems)
            {
                var item = menuStrip1.Items.Find(entry.Value, true);
                if (item.Length > 0)
                    item[0].Visible = false;
            }

            
            foreach (var entry in PERMISOMAP_BLL.MenuItems)
            {
                if (usuarioBLL.UsuarioTienePermiso(entry.Key))
                {
                    var item = menuStrip1.Items.Find(entry.Value, true);
                    if (item.Length > 0)
                        item[0].Visible = true;
                }
            }
        }
        private void bloqueadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMUsuariosBloqueados frm = new FRMUsuariosBloqueados();
            frm.ShowDialog();
        }

        private void gestionRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMGestionRoles frm = new FRMGestionRoles();
            frm.ShowDialog();
        }
    }
}
