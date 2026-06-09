using BE;
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
    public partial class InterfazGeneral : Form, Observer
    {
        BLL.USUARIO_BLL gestorusuario = new BLL.USUARIO_BLL();
        private bool _cargandoCombo = true;
        public InterfazGeneral()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Cerramos la sesión del usuario actual
            gestorusuario.Logout();
            TRADUCTOR_BLL.GetInstance().Eliminar(this); // Dejamos de observar

            // 2. BUSCAMOS EL IDIOMA BASE (ESPAÑOL) Y RESETEAMOS EL SISTEMA
            var idiomaBase = TRADUCTOR_BLL.GetInstance().ObtenerIdiomas().Find(i => i.Nombre.ToLower() == "español");
            if (idiomaBase != null)
            {
                // Le pasamos 0 en el ID de usuario para que esto NO se guarde en la BD de nadie,
                // solo cambia la interfaz temporalmente para el Login.
                TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaBase, 0);
            }

            this.Hide(); // Ocultamos la interfaz principal

            // 3. Abrimos el login de nuevo. ¡Ahora va a arrancar en Español limpito!
            Login log = new Login();
            log.ShowDialog();

            this.Close(); // Cerramos la app cuando terminen
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void InterfazGeneral_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);

            cmbIdiomaGlobal.DataSource = TRADUCTOR_BLL.GetInstance().ObtenerIdiomas();
            cmbIdiomaGlobal.DisplayMember = "Nombre";
            cmbIdiomaGlobal.ValueMember = "IdIdioma";
            var idiomaActual = TRADUCTOR_BLL.GetInstance().GetState();
            if (idiomaActual != null)
            {
                cmbIdiomaGlobal.SelectedValue = idiomaActual.IdIdioma;
            }
            AgregarLenguaje();
            _cargandoCombo = false;
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
            btnSalirInterfaz.BackColor = Color.Navy;
            btnSalirInterfaz.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnSalirInterfaz.BackColor = Color.White;
            btnSalirInterfaz.ForeColor = Color.Navy;
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
        private void InterfazGeneral_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
            Application.Exit();
        }

        public void AgregarLenguaje()
        {
            var idiomaActual = TRADUCTOR_BLL.GetInstance().GetState();
            if (idiomaActual != null)
            {
                this.Text = TRADUCTOR_BLL.GetInstance().Traducir(this.Name, this.Text);
                TraducirControles(this.Controls);
                TraducirMenu(menuStrip1.Items); 
            }
        }

        private void TraducirMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                item.Text = TRADUCTOR_BLL.GetInstance().Traducir(item.Name, item.Text);
                if (item is ToolStripMenuItem menuItem)
                {
                    TraducirMenu(menuItem.DropDownItems);
                }
            }
        }

        private void TraducirControles(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                // FILTRO CLAVE: Solo traducimos si NO es un control de ingreso de datos
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is NumericUpDown) && !(c is ListBox))
                {
                    c.Text = TRADUCTOR_BLL.GetInstance().Traducir(c.Name, c.Text);
                }

                // Las grillas se traducen aparte por sus columnas
                if (c is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.HeaderText = TRADUCTOR_BLL.GetInstance().Traducir(col.Name, col.HeaderText);
                    }
                }

                // Si tiene paneles o groupbox, entra recursivamente
                if (c.HasChildren)
                {
                    TraducirControles(c.Controls);
                }
            }
        }

        private void gestionIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMGestionIdiomas frm = new FRMGestionIdiomas();
            frm.ShowDialog();
        }

        private void cmbIdiomaGlobal_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!_cargandoCombo && cmbIdiomaGlobal.SelectedItem != null)
            {
                BE.IDIOMA nuevoIdioma = (BE.IDIOMA)cmbIdiomaGlobal.SelectedItem;
                int idUsuarioActivo = gestorusuario.ObtenerIdUsuarioActivo();
                TRADUCTOR_BLL.GetInstance().CambiarIdioma(nuevoIdioma, idUsuarioActivo);
            }
        }
    }
}
