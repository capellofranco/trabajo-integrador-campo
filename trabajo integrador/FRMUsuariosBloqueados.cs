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
    public partial class FRMUsuariosBloqueados : Form
    {
        USUARIO_BLL gestorusuario = new USUARIO_BLL();

        public FRMUsuariosBloqueados()
        {
            InitializeComponent();
        }

        private void FRMUsuariosBloqueados_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestorusuario.ObtenerUsuariosBloqueados();

            if (dataGridView1.Columns.Contains("Id"))
                dataGridView1.Columns["Id"].Visible = false;
            if (dataGridView1.Columns.Contains("Password"))
                dataGridView1.Columns["Password"].Visible = false;
            if (dataGridView1.Columns.Contains("Bloqueado"))
                dataGridView1.Columns["Bloqueado"].Visible = false;
            if (dataGridView1.Columns.Contains("Username"))
                dataGridView1.Columns["Username"].HeaderText = "Usuario";
            if (dataGridView1.Columns.Contains("IntentosFallidos"))
                dataGridView1.Columns["IntentosFallidos"].HeaderText = "Intentos fallidos";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un usuario de la lista.");
                return;
            }

            string nombreUsuario = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();

            var confirmacion = MessageBox.Show($"¿Desbloquear al usuario '{nombreUsuario}'?","Confirmar desbloqueo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                gestorusuario.DesbloquearUsuario(nombreUsuario);
                MessageBox.Show($"Usuario '{nombreUsuario}' desbloqueado correctamente.");
                CargarGrilla();
            }
        }
    }
}
