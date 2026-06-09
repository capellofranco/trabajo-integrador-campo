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
    public partial class FRMRegistrar : Form, Observer
    {
        USUARIO_BLL gestorusuario = new USUARIO_BLL();

        public FRMRegistrar()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Por favor, completar los campos.");
                return;
            }
            try
            {
                BE.USUARIO nuevoUsuario = new BE.USUARIO();
                nuevoUsuario.Username = textBox1.Text;
                nuevoUsuario.Password = textBox2.Text;
                gestorusuario.RegistrarUsuario(nuevoUsuario);
                MessageBox.Show("¡Usuario Registrado con Éxito!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrarRegistrar.BackColor = Color.Navy;
            btnRegistrarRegistrar.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrarRegistrar.BackColor = Color.White;
            btnRegistrarRegistrar.ForeColor = Color.Navy;
        }

        private void FRMRegistrar_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();
        }
        private void FRMRegistrar_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }
    }
}
