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

    public partial class FRMSolicitudes : Form
    {

        private SOLICITUD_BLL _solicitudBLL = new SOLICITUD_BLL();
        private RESERVA_BLL _reservaBLL = new RESERVA_BLL();
        private USUARIO_BLL _usuarioBLL = new USUARIO_BLL();
        private int _idUsuario;

        public FRMSolicitudes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un tipo de solicitud.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.");
                return;
            }
            if (comboBox1.SelectedItem.ToString() == "Cancelación de reserva" &&
                comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná la reserva que querés cancelar.");
                return;
            }

            try
            {
                var solicitud = new BE.SOLICITUD
                {
                    IdUsuario = _idUsuario,
                    Tipo = comboBox1.SelectedItem.ToString(),
                    Descripcion = textBox1.Text.Trim()
                };

                if (comboBox1.SelectedItem.ToString() == "Cancelación de reserva" &&
                    comboBox2.SelectedItem != null)
                {
                    solicitud.IdReserva = (int)comboBox2.SelectedValue;
                }

                int idSolicitud = _solicitudBLL.RegistrarSolicitud(solicitud);
                MessageBox.Show($"Solicitud registrada correctamente. Número: {idSolicitud}");
                textBox1.Clear();
                CargarSolicitudes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FRMSolicitudes_Load(object sender, EventArgs e)
        {
            _idUsuario = _usuarioBLL.ObtenerIdUsuarioActivo();
            CargarTipos();
            CargarReservasDelCliente();
            CargarSolicitudes();
            label2.Visible = false;
            comboBox2.Visible = false;
        }

        private void CargarTipos()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Consulta");
            comboBox1.Items.Add("Reclamo");
            comboBox1.Items.Add("Cancelación de reserva");
        }

        private void CargarReservasDelCliente()
        {
            var reservas = _reservaBLL.ListarReservasDeUsuario(_idUsuario);
            comboBox2.DataSource = null;
            comboBox2.DataSource = reservas;
            comboBox2.DisplayMember = "DestinoPaquete";
            comboBox2.ValueMember = "IdReserva";
        }

        private void CargarSolicitudes()
        {
            dgvSolicitudes.DataSource = null;
            dgvSolicitudes.DataSource = _solicitudBLL.ListarSolicitudesDeUsuario(_idUsuario);

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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esCancelacion = comboBox1.SelectedItem?.ToString() == "Cancelación de reserva";
            label2.Visible = esCancelacion;
            comboBox2.Visible = esCancelacion;
        }
    }
}
