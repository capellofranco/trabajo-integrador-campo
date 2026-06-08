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
        private bool _soloAdmin;
        public Login(bool soloAdmin = false)
        {
            InitializeComponent();
            _soloAdmin = soloAdmin;

            if (_soloAdmin)
            {
                lblAviso.Visible = true;
                lblAviso.Text = "⚠️ Sistema restringido. Solo puede ingresar el Administrador.";
                lblAviso.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Completá los campos correspondientes.");
                return;
            }

            bool login = usubll.Login(textBox1.Text, textBox2.Text);

            if (login)
            {
                if (_soloAdmin)
                {
                    bool esAdmin = usubll.EsAdministrador();

                    if (!esAdmin)
                    {
                        MessageBox.Show(
                            "El sistema está restringido por un error de integridad.\n" +
                            "Solo el Administrador puede ingresar.",
                            "Acceso restringido", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        usubll.Logout();
                        return;
                    }
                }

                InterfazGeneral i = new InterfazGeneral();
                i.Show();
                this.Hide();
            }
            else
            {
                var bloqueados = usubll.ObtenerUsuariosBloqueados();
                bool estaBloqueado = bloqueados.Exists(u => u.Username.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase));

                if (estaBloqueado)
                {
                    MessageBox.Show("Tu cuenta ha sido bloqueada por exceder el límite de intentos.\n" +"Contactá al administrador para recuperar el acceso.","Cuenta bloqueada",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.","Error de login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
