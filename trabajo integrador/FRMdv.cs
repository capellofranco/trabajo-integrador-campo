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
    public partial class FRMdv : Form
    {
        private BLL.DV_BLL _dvBLL = new BLL.DV_BLL();


        public FRMdv()
        {
            InitializeComponent();
        }

        private void Verificar()
        {
            lstErrores.Items.Clear();
            var errores = _dvBLL.VerificarIntegridad();

            if (errores.Count == 0)
            {
                lblEstado.Text = "✔ Integridad correcta. No se detectaron alteraciones.";
                lblEstado.ForeColor = Color.Green;
                btnRestaurar.Enabled = false;
            }
            else
            {
                lblEstado.Text = $"✘ Se detectaron {errores.Count} problema(s) de integridad.";
                lblEstado.ForeColor = Color.Red;
                btnRestaurar.Enabled = true;
                foreach (var error in errores)
                    lstErrores.Items.Add(error);
            }
        }


        private void btnVerificar_Click(object sender, EventArgs e)
        {
            Verificar();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Recalcular todos los dígitos verificadores?\n" +
                "Esto sincronizará los DVs con el estado actual de la base de datos.",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    _dvBLL.RecalcularTodo();
                    MessageBox.Show("Dígitos verificadores restaurados correctamente.");
                    Verificar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restaurar: " + ex.Message);
                }
            }
        }
    }
}
