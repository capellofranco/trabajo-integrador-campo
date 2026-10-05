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
    public partial class FRMGestionSolicitudes : Form
    {
        private SOLICITUD_BLL _solicitudBLL = new SOLICITUD_BLL();
        private RESERVA_BLL _reservaBLL = new RESERVA_BLL();
        private int _idSolicitudSeleccionada = -1;
        private string _tipoSeleccionado = "";

        public FRMGestionSolicitudes()
        {
            InitializeComponent();
        }

        private void FRMGestionSolicitudes_Load(object sender, EventArgs e)
        {
            CargarSolicitudes();
        }

        private void CargarSolicitudes()
        {
            dgvSolicitudes.DataSource = null;
            dgvSolicitudes.DataSource = _solicitudBLL.ListarTodasLasSolicitudes();

            if (dgvSolicitudes.Columns.Contains("IdSolicitud"))
                dgvSolicitudes.Columns["IdSolicitud"].Visible = false;
            if (dgvSolicitudes.Columns.Contains("IdUsuario"))
                dgvSolicitudes.Columns["IdUsuario"].Visible = false;
            if (dgvSolicitudes.Columns.Contains("IdEmpleado"))
                dgvSolicitudes.Columns["IdEmpleado"].Visible = false;
            if (dgvSolicitudes.Columns.Contains("IdReserva"))
                dgvSolicitudes.Columns["IdReserva"].Visible = false;
            if (dgvSolicitudes.Columns.Contains("DevolucionPago"))
                dgvSolicitudes.Columns["DevolucionPago"].Visible = false;

            LimpiarCampos();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvSolicitudes.Rows[e.RowIndex];

            _idSolicitudSeleccionada = (int)fila.Cells["IdSolicitud"].Value;
            _tipoSeleccionado = fila.Cells["Tipo"].Value.ToString();
            string estado = fila.Cells["Estado"].Value.ToString();

            label3.Text = fila.Cells["NombreCliente"].Value?.ToString() ?? "";
            label4.Text = _tipoSeleccionado;
            label5.Text = estado;
            label6.Text = fila.Cells["Descripcion"].Value?.ToString() ?? "";
            label7.Text = fila.Cells["DestinoPaquete"].Value?.ToString() ?? "—";
            label8.Text = fila.Cells["Respuesta"].Value?.ToString() ?? "Sin respuesta aún";

            bool esCancelacion = _tipoSeleccionado == "Cancelación de reserva";

            // Botón responder: disponible si está Pendiente o En revisión
            button1.Enabled = estado == "Pendiente" || estado == "En revisión";

            // Botón cerrar: solo para Consulta y Reclamo en estado Resuelta
            button2.Enabled = estado == "Resuelta" && !esCancelacion;

            // Botón cancelar reserva: solo para Cancelación de reserva en estado Resuelta
            button3.Enabled = estado == "Resuelta" && esCancelacion;

            // Botón cancelar solicitud: solo para Consulta y Reclamo en Pendiente o En revisión
            button4.Enabled = (estado == "Pendiente" || estado == "En revisión")
                                           && !esCancelacion;

            // Checkbox devolución: visible solo si es cancelación de reserva
            // con estado Resuelta y la reserva tiene pago registrado
            checkBox1.Visible = false;
            checkBox1.Checked = false;

            if (esCancelacion && estado == "Resuelta")
            {
                var fila2 = dgvSolicitudes.Rows[e.RowIndex];
                var idReservaCell = fila2.Cells["IdReserva"].Value;

                if (idReservaCell != null && idReservaCell != DBNull.Value)
                {
                    int idReserva = int.Parse(idReservaCell.ToString());
                    var pago = _reservaBLL.ObtenerPago(idReserva);
                    checkBox1.Visible = pago != null;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_idSolicitudSeleccionada == -1)
            {
                MessageBox.Show("Seleccioná una solicitud.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La respuesta no puede estar vacía.");
                return;
            }

            try
            {
                _solicitudBLL.ResponderSolicitud(_idSolicitudSeleccionada, textBox1.Text.Trim());
                MessageBox.Show("Solicitud respondida correctamente.");
                textBox1.Clear();
                CargarSolicitudes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_idSolicitudSeleccionada == -1)
            {
                MessageBox.Show("Seleccioná una solicitud.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Cerrar la solicitud seleccionada?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    _solicitudBLL.CerrarSolicitud(_idSolicitudSeleccionada, false);
                    MessageBox.Show("Solicitud cerrada correctamente.");
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LimpiarCampos()
        {
            _idSolicitudSeleccionada = -1;
            _tipoSeleccionado = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            textBox1.Clear();
            checkBox1.Visible = false;
            checkBox1.Checked = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_idSolicitudSeleccionada == -1)
            {
                MessageBox.Show("Seleccioná una solicitud.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Cancelar la reserva asociada a esta solicitud?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bool devolucion = checkBox1.Visible && checkBox1.Checked;
                    _solicitudBLL.CerrarSolicitud(_idSolicitudSeleccionada, devolucion);
                    MessageBox.Show("Reserva cancelada y solicitud cerrada correctamente.");
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_idSolicitudSeleccionada == -1)
            {
                MessageBox.Show("Seleccioná una solicitud.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Cancelar la solicitud seleccionada?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    _solicitudBLL.CancelarSolicitud(_idSolicitudSeleccionada);
                    MessageBox.Show("Solicitud cancelada correctamente.");
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}
