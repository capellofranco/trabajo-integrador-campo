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
    public partial class FRMUsuariosBloqueados : Form, Observer
    {
        USUARIO_BLL gestorusuario = new USUARIO_BLL();

        public FRMUsuariosBloqueados()
        {
            InitializeComponent();
        }

        private void FRMUsuariosBloqueados_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();
            CargarGrilla();
        }
        private void FRMUsuariosBloqueados_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }

        private void CargarGrilla()
        {
            dtwUsuarioBloqueado.DataSource = null;
            dtwUsuarioBloqueado.DataSource = gestorusuario.ObtenerUsuariosBloqueados();

            if (dtwUsuarioBloqueado.Columns.Contains("Id"))
                dtwUsuarioBloqueado.Columns["Id"].Visible = false;
            if (dtwUsuarioBloqueado.Columns.Contains("Password"))
                dtwUsuarioBloqueado.Columns["Password"].Visible = false;
            if (dtwUsuarioBloqueado.Columns.Contains("Bloqueado"))
                dtwUsuarioBloqueado.Columns["Bloqueado"].Visible = false;
            if (dtwUsuarioBloqueado.Columns.Contains("Username"))
                dtwUsuarioBloqueado.Columns["Username"].HeaderText = "Usuario";
            if (dtwUsuarioBloqueado.Columns.Contains("IntentosFallidos"))
                dtwUsuarioBloqueado.Columns["IntentosFallidos"].HeaderText = "Intentos fallidos";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtwUsuarioBloqueado.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un usuario de la lista.");
                return;
            }

            string nombreUsuario = dtwUsuarioBloqueado.CurrentRow.Cells["Username"].Value.ToString();

            var confirmacion = MessageBox.Show($"¿Desbloquear al usuario '{nombreUsuario}'?","Confirmar desbloqueo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                gestorusuario.DesbloquearUsuario(nombreUsuario);
                MessageBox.Show($"Usuario '{nombreUsuario}' desbloqueado correctamente.");
                CargarGrilla();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnDesbloquearUsuarioBloqueado.BackColor = Color.Navy;
            btnDesbloquearUsuarioBloqueado.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnDesbloquearUsuarioBloqueado.BackColor = Color.White;
            btnDesbloquearUsuarioBloqueado.ForeColor = Color.Navy;
        }

        public void AgregarLenguaje()
        {
            var idiomaActual = TRADUCTOR_BLL.GetInstance().GetState();
            if (idiomaActual != null)
            {
                this.Text = TRADUCTOR_BLL.GetInstance().Traducir(this.Name, this.Text);
                TraducirControles(this.Controls);
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
    }
}
