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
    public partial class FRMVerPaquetes : Form
    {
        private PAQUETE_BLL _paqueteBLL = new PAQUETE_BLL();
        private RESERVA_BLL _reservaBLL = new RESERVA_BLL();
        private CLIENTE_PERFIL_BLL _perfilBLL = new CLIENTE_PERFIL_BLL();
        private USUARIO_BLL _usuarioBLL = new USUARIO_BLL();
        public FRMVerPaquetes()
        {
            InitializeComponent();
        }

        private void FRMVerPaquetes_Load(object sender, EventArgs e)
        {
            CargarPaquetes();
            VerificarPerfil();
        }

        private void VerificarPerfil()
        {
            int idUsuario = _usuarioBLL.ObtenerIdUsuarioActivo();
            var perfil = _perfilBLL.ObtenerPerfil(idUsuario);

            if (perfil == null)
            {
                button1.Enabled = false;
                label4.Visible = true;
                label4.Text = "⚠ Completá tu perfil para poder realizar reservas.";
                button2.Visible = true;
            }
            else
            {
                button1.Enabled = true;
                label4.Visible = false;
                button2.Visible = false;
            }
        }

        private void CargarPaquetes()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _paqueteBLL.ListarPaquetes();
            if (dataGridView1.Columns.Contains("Activo"))
                dataGridView1.Columns["Activo"].Visible = false;
            if (dataGridView1.Columns.Contains("Servicios"))
                dataGridView1.Columns["Servicios"].Visible = false;
            if (dataGridView1.Columns.Contains("IdPaquete"))
                dataGridView1.Columns["IdPaquete"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idPaquete = (int)dataGridView1.Rows[e.RowIndex].Cells["IdPaquete"].Value;
            var servicios = _paqueteBLL.ListarServiciosDePaquete(idPaquete);
            listBox1.DataSource = null;
            listBox1.DataSource = servicios;
            listBox1.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un paquete de la lista.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresá la cantidad de personas.");
                return;
            }
            if (!int.TryParse(textBox1.Text, out int cantPersonas) || cantPersonas <= 0)
            {
                MessageBox.Show("La cantidad de personas debe ser un número mayor a cero.");
                return;
            }

            try
            {
                int idPaquete = (int)dataGridView1.CurrentRow.Cells["IdPaquete"].Value;
                int idUsuario = new USUARIO_BLL().ObtenerIdUsuarioActivo();
                decimal precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Precio"].Value);
                decimal importe = precio * cantPersonas;

                var confirmacion = MessageBox.Show(
                    $"Importe total: ${importe}\n¿Confirmar reserva?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    int idReserva = _reservaBLL.SolicitarReserva(idUsuario, idPaquete, cantPersonas);
                    MessageBox.Show($"Reserva solicitada. Número: {idReserva}");
                    textBox1.Clear();
                    CargarPaquetes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idUsuario = _usuarioBLL.ObtenerIdUsuarioActivo();
            FRMCompletarPerfil frm = new FRMCompletarPerfil(idUsuario);
            frm.ShowDialog();
            
            VerificarPerfil();
        }
    }
}
