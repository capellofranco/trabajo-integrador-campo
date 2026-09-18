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
    public partial class FRMCompletarPerfil : Form
    {
        private CLIENTE_PERFIL_BLL _perfilBLL = new CLIENTE_PERFIL_BLL();
        private int _idUsuario;
        public FRMCompletarPerfil(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        

        private void FRMCompletarPerfil_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre completo no puede estar vacío.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El DNI no puede estar vacío.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("El telefono no puede estar vacío.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("El email no puede estar vacío.");
                return;
            }


            try
            {
                var perfil = new BE.CLIENTE_PERFIL
                {
                    IdUsuario = _idUsuario,
                    NombreCompleto = textBox1.Text.Trim(),
                    DNI = textBox2.Text.Trim(),
                    Telefono = textBox3.Text.Trim(),
                    Email = textBox4.Text.Trim()
                };
                _perfilBLL.CrearPerfil(perfil);
                MessageBox.Show("Perfil completado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
    }
}
