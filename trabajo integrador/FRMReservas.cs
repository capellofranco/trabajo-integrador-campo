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
    public partial class FRMReservas : Form
    {
        private RESERVA_BLL _reservaBLL = new RESERVA_BLL();
        private bool _esAdmin;
        private int _idUsuario;

        public FRMReservas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FRMReservas_Load(object sender, EventArgs e)
        {
            var usuBLL = new USUARIO_BLL();
            _idUsuario = usuBLL.ObtenerIdUsuarioActivo();
            _esAdmin = usuBLL.UsuarioTienePermiso("GestionarReservas");

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Efectivo");
            comboBox1.Items.Add("Tarjeta de crédito");
            comboBox1.Items.Add("Tarjeta de débito");
            comboBox1.Items.Add("Transferencia");

            button2.Visible = _esAdmin;
            CargarReservas();
        }

        private void CargarReservas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _esAdmin
                ? _reservaBLL.ListarTodasLasReservas()
                : _reservaBLL.ListarReservasDeUsuario(_idUsuario);

            if (dataGridView1.Columns.Contains("IdReserva"))
                dataGridView1.Columns["IdReserva"].Visible = false;
            if (dataGridView1.Columns.Contains("IdUsuario"))
                dataGridView1.Columns["IdUsuario"].Visible = false;
            if (dataGridView1.Columns.Contains("IdPaquete"))
                dataGridView1.Columns["IdPaquete"].Visible = false;

            label1.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dataGridView1.Rows[e.RowIndex];
            int idReserva = (int)fila.Cells["IdReserva"].Value;
            string estado = fila.Cells["Estado"].Value.ToString();

            var pago = _reservaBLL.ObtenerPago(idReserva);
            label1.Text = pago != null
                ? $"Pago: ${pago.Monto} | {pago.MetodoPago} | {pago.Estado}"
                : "Sin pago registrado.";

            button1.Enabled = !_esAdmin && estado == "Pendiente" && pago == null;
            button2.Enabled = _esAdmin && estado == "Pendiente" && pago != null;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una reserva.");
                return;
            }
            if (!decimal.TryParse(textBox1.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número mayor a cero.");
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un método de pago.");
                return;
            }

            try
            {
                int idReserva = (int)dataGridView1.CurrentRow.Cells["IdReserva"].Value;
                string metodo = comboBox1.SelectedItem.ToString();
                _reservaBLL.RegistrarPago(idReserva, monto, metodo);
                MessageBox.Show("Pago registrado correctamente.");
                textBox1.Clear();
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una reserva.");
                return;
            }

            try
            {
                int idReserva = (int)dataGridView1.CurrentRow.Cells["IdReserva"].Value;
                _reservaBLL.ConfirmarReserva(idReserva);
                MessageBox.Show("Reserva confirmada correctamente.");
                CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
    }
}
