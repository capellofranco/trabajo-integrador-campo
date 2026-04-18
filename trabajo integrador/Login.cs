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
    public partial class Login : Form
    {

        USUARIO_BLL usubll = new USUARIO_BLL();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Completa los campos correspondientes");
            }
            else
            {
                bool login = usubll.Login(textBox1.Text, textBox2.Text);

                if (login)
                {
                    InterfazGeneral i = new InterfazGeneral();
                    i.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
            }

               
        }
    }
}
