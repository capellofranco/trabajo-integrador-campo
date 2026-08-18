using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace trabajo_integrador
{
    public partial class FRMBitacora : Form, Observer
    {

        BITACORA_BLL gestorbitacora = new BITACORA_BLL();

        public FRMBitacora()
        {
            InitializeComponent();
        }

        private void FRMBitacora_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();

            cmbCriticidad.Items.Clear();
            cmbCriticidad.Items.Add("Todos");
            cmbCriticidad.Items.Add("INFO");
            cmbCriticidad.Items.Add("WARNING");
            cmbCriticidad.Items.Add("ERROR");
            cmbCriticidad.SelectedIndex = 0;

            cmbModulo.Items.Clear();
            cmbModulo.Items.Add("Todos");
            cmbModulo.Items.Add("Seguridad");
            cmbModulo.Items.Add("Usuarios");
            cmbModulo.Items.Add("Gestión Roles");
            cmbModulo.Items.Add("Productos");
            cmbModulo.Items.Add("Control de Cambios");
            cmbModulo.Items.Add("Gestión de Idiomas");
            cmbModulo.SelectedIndex = 0;

            CargarGrilla();
        }

        private void CargarGrilla(BE.BITACORA objFiltros = null, DateTime? desde = null, DateTime? hasta = null)
        {
            if (objFiltros == null)
            {
                objFiltros = new BE.BITACORA();
            }

            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = gestorbitacora.ObtenerRegistros(objFiltros, desde, hasta);

            if (dgvBitacora.Columns.Contains("IdBitacora"))
                dgvBitacora.Columns["IdBitacora"].Visible = false;

            if (dgvBitacora.Columns.Contains("IdUsuario"))
                dgvBitacora.Columns["IdUsuario"].Visible = false;

            if (dgvBitacora.Columns.Contains("FechaHora"))
                dgvBitacora.Columns["FechaHora"].HeaderText = "Fecha y Hora";

            if (dgvBitacora.Columns.Contains("NombreUsuario"))
                dgvBitacora.Columns["NombreUsuario"].HeaderText = "Usuario";

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewRow row in dgvBitacora.Rows)
            {
                if (row.Cells["Criticidad"].Value != null)
                {
                    string criticidad = row.Cells["Criticidad"].Value.ToString();

                    if (criticidad == "ERROR")
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    else if (criticidad == "WARNING")
                        row.DefaultCellStyle.BackColor = Color.Khaki;
                }
            }
        }

        private void button2_Click( object sender, EventArgs e)
        {
            BE.BITACORA objFiltros = new BE.BITACORA();

            objFiltros.NombreUsuario = string.IsNullOrWhiteSpace(txtUsuario.Text) ? null : txtUsuario.Text.Trim();

            string criticidad = cmbCriticidad.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(criticidad) || criticidad == "Todos")
            {
                objFiltros.Criticidad = null;
            }
            else
            {
                objFiltros.Criticidad = criticidad;
            }
            string modulo = cmbModulo.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(modulo) || modulo == "Todos")
            {
                objFiltros.Modulo = null;
            }
            else
            {
                objFiltros.Modulo = modulo;
            }
            CargarGrilla(objFiltros, dtpDesde.Value, dtpHasta.Value);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btnFiltrarBitacora.BackColor = Color.Navy;
            btnFiltrarBitacora.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            btnFiltrarBitacora.BackColor = Color.White;
            btnFiltrarBitacora.ForeColor = Color.Navy;
        }
        private void FRMBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
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
    }
}
