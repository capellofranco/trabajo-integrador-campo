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
    public partial class FRMdv : Form, Observer
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

        private void btnVerificar_MouseEnter(object sender, EventArgs e)
        {
            btnVerificar.BackColor = Color.Navy;
            btnVerificar.ForeColor = Color.White;
        }

        private void btnVerificar_MouseLeave(object sender, EventArgs e)
        {
            btnVerificar.BackColor = Color.White;
            btnVerificar.ForeColor = Color.Navy;
        }

        private void btnRestaurar_MouseEnter(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.Navy;
            btnRestaurar.ForeColor = Color.White;
        }

        private void btnRestaurar_MouseLeave(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.White;
            btnRestaurar.ForeColor = Color.Navy;
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
                
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is NumericUpDown) && !(c is ListBox))
                {
                    c.Text = TRADUCTOR_BLL.GetInstance().Traducir(c.Name, c.Text);
                }

                
                if (c is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.HeaderText = TRADUCTOR_BLL.GetInstance().Traducir(col.Name, col.HeaderText);
                    }
                }

               
                if (c.HasChildren)
                {
                    TraducirControles(c.Controls);
                }
            }
        }

        private void FRMdv_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();
        }
        private void FRMdv_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }
    }
}
