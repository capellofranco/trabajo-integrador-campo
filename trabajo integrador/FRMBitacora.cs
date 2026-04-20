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
    public partial class FRMBitacora : Form
    {

        BITACORA_BLL gestorbitacora = new BITACORA_BLL();

        public FRMBitacora()
        {
            InitializeComponent();
        }

        private void FRMBitacora_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla(DateTime? desde = null, DateTime? hasta = null)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestorbitacora.ObtenerRegistros(desde, hasta);

            if (dataGridView1.Columns.Contains("IdBitacora"))
                dataGridView1.Columns["IdBitacora"].Visible = false;

            if (dataGridView1.Columns.Contains("IdUsuario"))
                dataGridView1.Columns["IdUsuario"].Visible = false;

            if (dataGridView1.Columns.Contains("FechaHora"))
                dataGridView1.Columns["FechaHora"].HeaderText = "Fecha y Hora";

            if (dataGridView1.Columns.Contains("NombreUsuario"))
                dataGridView1.Columns["NombreUsuario"].HeaderText = "Usuario";
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
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

        private void button2_Click(object sender, EventArgs e)
        {
            CargarGrilla(dtpDesde.Value, dtpHasta.Value);
        }
    }
}
