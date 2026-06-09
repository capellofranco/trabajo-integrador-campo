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
    public partial class FRMGestionIdiomas : Form, Observer
    {
        private bool _cargando = true;

        public FRMGestionIdiomas()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbIdiomasEditar.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un idioma de la lista primero.");
                return;
            }

            BE.IDIOMA idiomaSel = (BE.IDIOMA)cmbIdiomasEditar.SelectedItem;
            List<BE.TRADUCCION> listaTraducciones = new List<BE.TRADUCCION>();

            // Recorremos la grilla y guardamos todo
            foreach (DataGridViewRow row in dgvTraducciones.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    string control = row.Cells[0].Value.ToString();
                    string texto = row.Cells[1].Value?.ToString() ?? "";

                    if (!string.IsNullOrWhiteSpace(texto))
                    {
                        listaTraducciones.Add(new BE.TRADUCCION
                        {
                            IdIdioma = idiomaSel.IdIdioma,
                            NombreControl = control,
                            Texto = texto
                        });
                    }
                }
            }

            // Enviamos la lista a la BLL
            TRADUCTOR_BLL.GetInstance().GuardarTraducciones(listaTraducciones);

            MessageBox.Show("Traducciones actualizadas correctamente.");

            // Si editaste el idioma actual, lo refresca en tiempo real
            if (TRADUCTOR_BLL.GetInstance().GetState().IdIdioma == idiomaSel.IdIdioma)
            {
                TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaSel, new USUARIO_BLL().ObtenerIdUsuarioActivo());
            }
        }

        private void FRMGestionIdiomas_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            CargarCombo();
            AgregarLenguaje();
            _cargando = false;
        }

        private void CargarCombo()
        {
            _cargando = true;
            cmbIdiomasEditar.DataSource = null;
            cmbIdiomasEditar.DataSource = TRADUCTOR_BLL.GetInstance().ObtenerIdiomas();
            cmbIdiomasEditar.DisplayMember = "Nombre";
            cmbIdiomasEditar.ValueMember = "IdIdioma";
            cmbIdiomasEditar.SelectedIndex = -1;
            _cargando = false;
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
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is NumericUpDown) && !(c is ListBox) && !(c is DataGridView))
                {
                    c.Text = TRADUCTOR_BLL.GetInstance().Traducir(c.Name, c.Text);
                }

                if (c is DataGridView dgv && dgv.Name != "dgvTraducciones")
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.HeaderText = TRADUCTOR_BLL.GetInstance().Traducir(col.Name, col.HeaderText);
                    }
                }

                if (c.HasChildren) TraducirControles(c.Controls);
            }
        }

        private void FRMGestionIdiomas_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }

        private void btnCrearIdioma_Click(object sender, EventArgs e)
        {
            string nuevoIdioma = txtNombreIdioma.Text.Trim();
            if (string.IsNullOrEmpty(nuevoIdioma))
            {
                MessageBox.Show("Ingresá un nombre para el nuevo idioma.");
                return;
            }
            TRADUCTOR_BLL.GetInstance().CrearNuevoIdioma(nuevoIdioma);
            MessageBox.Show($"Idioma '{nuevoIdioma}' creado correctamente. Ahora seleccionalo en la lista para traducirlo.");
            txtNombreIdioma.Clear();
            CargarCombo();
        }

        private void cmbIdiomasEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando || cmbIdiomasEditar.SelectedItem == null) return;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvTraducciones.Rows.Clear();
            BE.IDIOMA idiomaSel = (BE.IDIOMA)cmbIdiomasEditar.SelectedItem;
            var traduccionesBD = TRADUCTOR_BLL.GetInstance().ObtenerTraduccionesDelIdioma(idiomaSel.IdIdioma);
            foreach (string controlName in TRADUCTOR_BLL.GetInstance().ControlesDescubiertos)
            {
                string textoTraducido = traduccionesBD.ContainsKey(controlName) ? traduccionesBD[controlName] : "";
                dgvTraducciones.Rows.Add(controlName, textoTraducido);
            }
        }

        private void btnCrearIdioma_MouseEnter(object sender, EventArgs e)
        {
            btnCrearIdioma.BackColor = Color.Navy;
            btnCrearIdioma.ForeColor = Color.White;
        }

        private void btnCrearIdioma_MouseLeave(object sender, EventArgs e)
        {
            btnCrearIdioma.BackColor = Color.White;
            btnCrearIdioma.ForeColor = Color.Navy;
        }

        private void btnActualizar_MouseEnter(object sender, EventArgs e)
        {
            btnActualizar.BackColor = Color.Navy;
            btnActualizar.ForeColor = Color.White;
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = Color.Navy;
        }
    }
}
