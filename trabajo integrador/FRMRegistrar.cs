using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajo_integrador
{
    public partial class FRMRegistrar : Form
    {
        public FRMRegistrar()
        {
            InitializeComponent();
        }
        private USUARIO_BLL gestorusuario = new USUARIO_BLL();


        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Por favor, Completar los campos.");
                return;
            }
            try
            {
                USUARIO nuevoUsuario = new USUARIO();
                nuevoUsuario.Username = textBox1.Text;
                nuevoUsuario.Password = textBox2.Text;
                gestorusuario.RegistrarUsuario(nuevoUsuario);
                MessageBox.Show("¡Usuario Registrado con Exito!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
