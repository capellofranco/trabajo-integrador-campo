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
    public partial class FRMProductoABM : Form, Observer
    {
        BLL.PRODUCTO_BLL gestorProducto = new BLL.PRODUCTO_BLL();

        public FRMProductoABM()
        {
            InitializeComponent();
        }

        private void FRMProductoABM_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();
            CargarGrilla();
        }
        private void FRMProductoABM_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }

        private void CargarGrilla()
        {
            dgwProductoABM.DataSource = null;
            dgwProductoABM.DataSource = gestorProducto.ListarProductos();
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
            if (dgwProductoABM.CurrentRow == null)
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
                int id = (int)dgwProductoABM.CurrentRow.Cells["ID"].Value;
                string nombreActual = dgwProductoABM.CurrentRow.Cells["Nombre"].Value.ToString();
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
            if (dgwProductoABM.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un producto de la grilla para eliminar.");
                return;
            }

            try
            {
                BE.PRODUCTO prod = new BE.PRODUCTO();
                prod.ID = (int)dgwProductoABM.CurrentRow.Cells["ID"].Value;
                prod.Nombre = dgwProductoABM.CurrentRow.Cells["Nombre"].Value.ToString();
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
            btnAgregarProducto.BackColor = Color.Navy;
            btnAgregarProducto.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            btnAgregarProducto.BackColor = Color.White;
            btnAgregarProducto.ForeColor = Color.Navy;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnModificarProducto.BackColor = Color.Navy;
            btnModificarProducto.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnModificarProducto.BackColor = Color.White;
            btnModificarProducto.ForeColor = Color.Navy;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarProducto.BackColor = Color.Navy;
            btnEliminarProducto.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarProducto.BackColor = Color.White;
            btnEliminarProducto.ForeColor = Color.Navy;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgwProductoABM.CurrentRow != null)
            {
                txtNombre.Text = dgwProductoABM.CurrentRow.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgwProductoABM.CurrentRow.Cells["PrecioActual"].Value.ToString();
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
