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
            
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void InterfazGeneral_Load(object sender, EventArgs e)
        {

        }

        private void AplicarVisibilidad()
        {
            USUARIO_BLL usuarioBLL = new USUARIO_BLL();

            // Items directos
            foreach (var entry in PERMISOMAP_BLL.ItemsDirectos)
            {
                var item = menuStrip1.Items.Find(entry.Value, true);
                if (item.Length > 0)
                    item[0].Visible = usuarioBLL.UsuarioTienePermiso(entry.Key);
            }

            // Items con padre
            foreach (var grupo in PERMISOMAP_BLL.ItemsConPadre)
            {
                var padreItem = menuStrip1.Items.Find(grupo.Key, true);
                if (padreItem.Length == 0) continue;

                var padre = (ToolStripMenuItem)padreItem[0];
                padre.DropDownItems.Clear();

                foreach (var hijo in grupo.Value)
                {
                    if (usuarioBLL.UsuarioTienePermiso(hijo.Permiso))
                    {
                        var nuevoItem = new ToolStripMenuItem(hijo.Texto);
                        nuevoItem.Click += ObtenerHandler(hijo.Handler);
                        padre.DropDownItems.Add(nuevoItem);
                    }
                }

                padre.Visible = padre.DropDownItems.Count > 0;
            }
        }

        private EventHandler ObtenerHandler(string nombreHandler)
        {
            switch (nombreHandler)
            {
                case "bitacoraToolStripMenuItem1_Click":
                    return bitacoraToolStripMenuItem1_Click;
                case "historicoToolStripMenuItem_Click":
                    return historicoToolStripMenuItem_Click;
                case "usuarioToolStripMenuItem_Click":
                    return usuarioToolStripMenuItem_Click;
                case "productoToolStripMenuItem1_Click":
                    return productoToolStripMenuItem1_Click;
                default:
                    return null;
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

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRegistrar frm = new FRMRegistrar();
            frm.ShowDialog();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Navy;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Navy;
        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRMProductoABM frm = new FRMProductoABM();  
            frm.ShowDialog();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMProducto frm = new FRMProducto();
            frm.ShowDialog();
        }

        private void bitacoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRMBitacora frm = new FRMBitacora();
            frm.ShowDialog();
        }

        private void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMHistorico frm = new FRMHistorico();  
            frm.ShowDialog();
        }

        private void digitoVerificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMdv frm = new FRMdv();
            frm.ShowDialog();
            
        }

        private void InterfazGeneral_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => AplicarVisibilidad()));
        }
    }
}
