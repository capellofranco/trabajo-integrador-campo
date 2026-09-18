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
    public partial class FRMGestionPaquetes : Form
    {
        private PAQUETE_BLL _paqueteBLL = new PAQUETE_BLL();
        private int _idPaqueteSeleccionado = -1;
        public FRMGestionPaquetes()
        {
            InitializeComponent();
        }

        private void FRMGestionPaquetes_Load(object sender, EventArgs e)
        {
            CargarPaquetes();
            CargarServicios();
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

        private void CargarServicios()
        {
            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = _paqueteBLL.ListarServicios();
            checkedListBox1.DisplayMember = "Nombre";
            checkedListBox1.ValueMember = "IdServicio";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dataGridView1.Rows[e.RowIndex];
            _idPaqueteSeleccionado = (int)fila.Cells["IdPaquete"].Value;

            textBox1.Text = fila.Cells["Destino"].Value.ToString();
            textBox2.Text = fila.Cells["Descripcion"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["FechaSalida"].Value);
            dateTimePicker2.Value = Convert.ToDateTime(fila.Cells["FechaRegreso"].Value);
            textBox3.Text = fila.Cells["DuracionDias"].Value.ToString();
            textBox4.Text = fila.Cells["Precio"].Value.ToString();
            textBox5.Text = fila.Cells["CuposTotal"].Value.ToString();

            var serviciosPaquete = _paqueteBLL.ListarServiciosDePaquete(_idPaqueteSeleccionado);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                var servicio = (BE.SERVICIO)checkedListBox1.Items[i];
                checkedListBox1.SetItemChecked(i,
                    serviciosPaquete.Exists(s => s.IdServicio == servicio.IdServicio));
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El destino no puede estar vacío.");
                return;
            }
            if (!decimal.TryParse(textBox4.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a cero.");
                return;
            }
            if (!int.TryParse(textBox5.Text, out int cupos) || cupos <= 0)
            {
                MessageBox.Show("Los cupos deben ser un número mayor a cero.");
                return;
            }
            if (!int.TryParse(textBox3.Text, out int duracion) || duracion <= 0)
            {
                MessageBox.Show("La duración debe ser un número mayor a cero.");
                return;
            }
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("La fecha de regreso debe ser posterior a la de salida.");
                return;
            }

            try
            {
                var paquete = new BE.PAQUETE
                {
                    Destino = textBox1.Text.Trim(),
                    Descripcion = textBox2.Text.Trim(),
                    FechaSalida = dateTimePicker1.Value,
                    FechaRegreso = dateTimePicker2.Value,
                    DuracionDias = duracion,
                    Precio = precio,
                    CuposTotal = cupos
                };
                int idPaquete = _paqueteBLL.InsertarPaquete(paquete);

                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    var servicio = (BE.SERVICIO)checkedListBox1.Items[i];
                    _paqueteBLL.AgregarServicioAPaquete(idPaquete, servicio.IdServicio);
                }

                MessageBox.Show("Paquete agregado correctamente.");
                LimpiarCampos();
                CargarPaquetes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_idPaqueteSeleccionado == -1)
            {
                MessageBox.Show("Seleccioná un paquete de la lista.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El destino no puede estar vacío.");
                return;
            }
            if (!decimal.TryParse(textBox4.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a cero.");
                return;
            }
            if (!int.TryParse(textBox5.Text, out int cupos) || cupos <= 0)
            {
                MessageBox.Show("Los cupos deben ser un número mayor a cero.");
                return;
            }
            if (!int.TryParse(textBox3.Text, out int duracion) || duracion <= 0)
            {
                MessageBox.Show("La duración debe ser un número mayor a cero.");
                return;
            }
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("La fecha de regreso debe ser posterior a la de salida.");
                return;
            }

            try
            {
                var paquete = new BE.PAQUETE
                {
                    IdPaquete = _idPaqueteSeleccionado,
                    Destino = textBox1.Text.Trim(),
                    Descripcion = textBox2.Text.Trim(),
                    FechaSalida = dateTimePicker1.Value,
                    FechaRegreso = dateTimePicker2.Value,
                    DuracionDias = duracion,
                    Precio = precio,
                    CuposTotal = cupos
                };
                _paqueteBLL.ModificarPaquete(paquete);
                var serviciosActuales = _paqueteBLL.ListarServiciosDePaquete(_idPaqueteSeleccionado);
                foreach (var s in serviciosActuales)
                    _paqueteBLL.QuitarServicioDePaquete(_idPaqueteSeleccionado, s.IdServicio);

                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    var servicio = (BE.SERVICIO)checkedListBox1.Items[i];
                    _paqueteBLL.AgregarServicioAPaquete(_idPaqueteSeleccionado, servicio.IdServicio);
                }

                MessageBox.Show("Paquete modificado correctamente.");
                LimpiarCampos();
                CargarPaquetes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_idPaqueteSeleccionado == -1)
            {
                MessageBox.Show("Seleccioná un paquete de la lista.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Dar de baja el paquete seleccionado?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var paquete = new BE.PAQUETE
                    {
                        IdPaquete = _idPaqueteSeleccionado,
                        Destino = textBox1.Text.Trim()
                    };
                    _paqueteBLL.EliminarPaquete(paquete);
                    MessageBox.Show("Paquete dado de baja.");
                    LimpiarCampos();
                    CargarPaquetes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void LimpiarCampos()
        {
            _idPaqueteSeleccionado = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }
    }
}
