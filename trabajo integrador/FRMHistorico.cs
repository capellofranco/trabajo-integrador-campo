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
    public partial class FRMHistorico : Form
    {
        BLL.PRODUCTO_BLL gestorProducto = new BLL.PRODUCTO_BLL();

        List<BE.HistoricoPrecio> listaHistoria;
        int indiceActual = 0;
        int idProductoSeleccionado = -1;
        string nombreProductoSeleccionado = "";

        public FRMHistorico()
        {
            InitializeComponent();
        }

        private void FRMHistorico_Load(object sender, EventArgs e)
        {
            btnAtras.Enabled = false;
            btnAdelante.Enabled = false;
            btnRestaurar.Enabled = false;

            CargarGrillaProductos();
        }

        private void CargarGrillaProductos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestorProducto.ListarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.CurrentRow != null)
            {
                idProductoSeleccionado = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                nombreProductoSeleccionado = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                CargarHistoriaDelProducto();
            }
        }

        private void CargarHistoriaDelProducto()
        {
            listaHistoria = gestorProducto.ObtenerHistorico(idProductoSeleccionado);

            if (listaHistoria == null || listaHistoria.Count == 0)
            {
                lblPrecioInfo.Text = "Sin historial.";
                lblAuditoria.Text = "";
                btnAtras.Enabled = false;
                btnAdelante.Enabled = false;
                btnRestaurar.Enabled = false;
                return;
            }
            indiceActual = listaHistoria.Count - 1;
            MostrarRegistroTemporal();
        }

        private void MostrarRegistroTemporal()
        {
            var registro = listaHistoria[indiceActual];

            lblPrecioInfo.Text = $"Precio Histórico: ${registro.Precio}";
            lblAuditoria.Text = $"Fecha: {registro.FechaModificacion} | Por: {registro.NombreUsuario}";
            btnAtras.Enabled = (indiceActual > 0);
            btnAdelante.Enabled = (indiceActual < listaHistoria.Count - 1);
            btnRestaurar.Enabled = (indiceActual != listaHistoria.Count - 1);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
                MostrarRegistroTemporal();
            }
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (indiceActual < listaHistoria.Count - 1)
            {
                indiceActual++;
                MostrarRegistroTemporal();
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            var registro = listaHistoria[indiceActual];

            var confirmacion = MessageBox.Show($"¿Restaurar el producto '{nombreProductoSeleccionado}' al precio antiguo de ${registro.Precio}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                gestorProducto.RestaurarPrecio(idProductoSeleccionado, nombreProductoSeleccionado, registro.Precio);
                MessageBox.Show("Precio restaurado exitosamente.");
                CargarGrillaProductos();
                CargarHistoriaDelProducto();
            }
        }

        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            btnAtras.BackColor = Color.Navy;
            btnAtras.ForeColor = Color.White;
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            btnAtras.BackColor = Color.White;
            btnAtras.ForeColor = Color.Navy;
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

        private void btnAdelante_MouseEnter(object sender, EventArgs e)
        {
            btnAdelante.BackColor = Color.Navy;
            btnAdelante.ForeColor = Color.White;
        }

        private void btnAdelante_MouseLeave(object sender, EventArgs e)
        {
            btnAdelante.BackColor = Color.White;
            btnAdelante.ForeColor = Color.Navy;
        }
    }
}
