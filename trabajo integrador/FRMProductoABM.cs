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
    public partial class FRMProductoABM : Form
    {
        BLL.PRODUCTO_BLL gestorProducto = new BLL.PRODUCTO_BLL();

        public FRMProductoABM()
        {
            InitializeComponent();
        }

        private void FRMProductoABM_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestorProducto.ListarProductos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, completá el nombre y el precio.");
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precioValido))
            {
                MessageBox.Show("El formato del precio no es válido.");
                return;
            }
            if (precioValido > 99999999m) 
            {
                MessageBox.Show("El precio ingresado es demasiado alto. Ingresá un valor más razonable.");
                return;
            }
            if (precioValido <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.");
                return;
            }
            try
            {
                BE.PRODUCTO nuevo = new BE.PRODUCTO();
                nuevo.Nombre = txtNombre.Text.Trim(); 
                nuevo.PrecioActual = precioValido;
                gestorProducto.InsertarProducto(nuevo);
                MessageBox.Show("Producto agregado.");
                txtNombre.Clear();
                txtPrecio.Clear();
                CargarGrilla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un producto de la grilla para modificar.");
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precioValido) || precioValido <= 0 || precioValido > 99999999m)
            {
                MessageBox.Show("El precio ingresado no es válido.");
                return;
            }
            try
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                string nombreActual = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                gestorProducto.ModificarPrecio(id, nombreActual, precioValido);
                MessageBox.Show("Precio modificado con éxito.");
                CargarGrilla();
                LimpiarCampos(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un producto de la grilla para eliminar.");
                return;
            }

            try
            {
                BE.PRODUCTO prod = new BE.PRODUCTO();
                prod.ID = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                prod.Nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                var confirmacion = MessageBox.Show($"¿Dar de baja el producto '{prod.Nombre}'?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    gestorProducto.EliminarProducto(prod);
                    MessageBox.Show("Producto dado de baja.");
                    CargarGrilla();
                    LimpiarCampos(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Navy;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Navy;
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Navy;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Navy;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.CurrentRow != null)
            {
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["PrecioActual"].Value.ToString();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                if (e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true; 
                }
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtNombre.Focus();
        }
    }
}
