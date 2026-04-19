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
        BLL.USUARIO_BLL gestorusuario = new BLL.USUARIO_BLL();
        public InterfazGeneral()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestorusuario.Logout();
            this.Close();
            Application.Restart();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRegistrar frm = new FRMRegistrar();
            frm.ShowDialog();
        }
    }
}
