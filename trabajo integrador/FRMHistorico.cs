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
    public partial class FRMHistorico : Form, Observer
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
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();
            btnAtrasHistorico.Enabled = false;
            btnAdelanteHistorico.Enabled = false;
            btnRestaurarHistorico.Enabled = false;

            CargarGrillaProductos();
        }
        private void FRMHistorico_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }

        private void CargarGrillaProductos()
        {
            dgwHistoricoProducto.DataSource = null;
            dgwHistoricoProducto.DataSource = gestorProducto.ListarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgwHistoricoProducto.CurrentRow != null)
            {
                idProductoSeleccionado = (int)dgwHistoricoProducto.CurrentRow.Cells["ID"].Value;
                nombreProductoSeleccionado = dgwHistoricoProducto.CurrentRow.Cells["Nombre"].Value.ToString();
                CargarHistoriaDelProducto();
            }
        }

        private void CargarHistoriaDelProducto()
        {
            listaHistoria = gestorProducto.ObtenerHistorico(idProductoSeleccionado);

            if (listaHistoria == null || listaHistoria.Count == 0)
            {
                lblPrecioInfoHistorico.Text = "Sin historial.";
                lblAuditoriaHistorico.Text = "";
                btnAtrasHistorico.Enabled = false;
                btnAdelanteHistorico.Enabled = false;
                btnRestaurarHistorico.Enabled = false;
                return;
            }
            indiceActual = listaHistoria.Count - 1;
            MostrarRegistroTemporal();
        }

        private void MostrarRegistroTemporal()
        {
            var registro = listaHistoria[indiceActual];

            lblPrecioInfoHistorico.Text = $"Precio Histórico: ${registro.Precio}";
            lblAuditoriaHistorico.Text = $"Fecha: {registro.FechaModificacion} | Por: {registro.NombreUsuario}";
            btnAtrasHistorico.Enabled = (indiceActual > 0);
            btnAdelanteHistorico.Enabled = (indiceActual < listaHistoria.Count - 1);
            btnRestaurarHistorico.Enabled = (indiceActual != listaHistoria.Count - 1);
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
            btnAtrasHistorico.BackColor = Color.Navy;
            btnAtrasHistorico.ForeColor = Color.White;
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            btnAtrasHistorico.BackColor = Color.White;
            btnAtrasHistorico.ForeColor = Color.Navy;
        }

        private void btnRestaurar_MouseEnter(object sender, EventArgs e)
        {
            btnRestaurarHistorico.BackColor = Color.Navy;
            btnRestaurarHistorico.ForeColor = Color.White;
        }

        private void btnRestaurar_MouseLeave(object sender, EventArgs e)
        {
            btnRestaurarHistorico.BackColor = Color.White;
            btnRestaurarHistorico.ForeColor = Color.Navy;
        }

        private void btnAdelante_MouseEnter(object sender, EventArgs e)
        {
            btnAdelanteHistorico.BackColor = Color.Navy;
            btnAdelanteHistorico.ForeColor = Color.White;
        }

        private void btnAdelante_MouseLeave(object sender, EventArgs e)
        {
            btnAdelanteHistorico.BackColor = Color.White;
            btnAdelanteHistorico.ForeColor = Color.Navy;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
