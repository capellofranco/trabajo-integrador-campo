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
    public partial class FRMRegistrar : Form
    {
        USUARIO_BLL gestorusuario = new USUARIO_BLL();

        public FRMRegistrar()
        {
            InitializeComponent();
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
            button1.BackColor = Color.Navy;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Navy;
        }
    }
}
