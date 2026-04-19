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
    public partial class InterfazGeneral : Form
    {
        public InterfazGeneral()
        {
            InitializeComponent();
        }

        private USUARIO_BLL gestorusuario = new USUARIO_BLL();

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRegistrar registrar = new FRMRegistrar();
            registrar.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestorusuario.Logout();
            this.Close();
            Application.Restart();
        }

        private void InterfazGeneral_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
