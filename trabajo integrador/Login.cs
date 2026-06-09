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
                        MessageBox.Show("Sistema restringido.", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        usubll.Logout();
                        return;
                    }
                }

                int idUsuarioLogueado = usubll.ObtenerIdUsuarioActivo();
                var usuarioLogueado = usubll.ObtenerUsuarioSesion();
                BE.IDIOMA idiomaElegido = (BE.IDIOMA)cmbIdiomas.SelectedItem;

                // LÓGICA DE PRIORIDADES AL INICIAR SESIÓN
                if (_idiomaCambiadoManualmente)
                {
                    // Prioridad 1: El usuario cambió el combo a propósito en el login, se lo guardamos
                    TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaElegido, idUsuarioLogueado);
            }
                else if (usuarioLogueado?.IdIdioma != null)
                {
                    // Prioridad 2: No tocó el combo, pero tiene un idioma en la base. ¡Gana la base de datos!
                    var idiomasDisponibles = TRADUCTOR_BLL.GetInstance().ObtenerIdiomas();
                    var idiomaGuardado = idiomasDisponibles.Find(x => x.IdIdioma == usuarioLogueado.IdIdioma.Value);
                    if (idiomaGuardado != null)
                    {
                        TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaGuardado, idUsuarioLogueado);
                    }
                }
            else
            {
                    // Prioridad 3: No tocó nada y es un usuario nuevo, le damos el que esté en el combo
                    TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaElegido, idUsuarioLogueado);
                }

                TRADUCTOR_BLL.GetInstance().Eliminar(this); // Limpiamos memoria

                InterfazGeneral interfazPrincipal = new InterfazGeneral();
                interfazPrincipal.Show();
                this.Hide();
                }
                else
                {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            TRADUCTOR_BLL.GetInstance().Agregar(this);

            cmbIdiomas.DataSource = TRADUCTOR_BLL.GetInstance().ObtenerIdiomas();
            cmbIdiomas.DisplayMember = "Nombre";
            cmbIdiomas.ValueMember = "IdIdioma";
            var idiomaActual = TRADUCTOR_BLL.GetInstance().GetState();
            if (idiomaActual != null)
            {
                cmbIdiomas.SelectedValue = idiomaActual.IdIdioma;
            }

            AgregarLenguaje();
            _cargandoCombo = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_cargandoCombo && cmbIdiomas.SelectedItem != null && cmbIdiomas.Focused)
            {
                _idiomaCambiadoManualmente = true; // El usuario forzó un idioma
                BE.IDIOMA nuevoIdioma = (BE.IDIOMA)cmbIdiomas.SelectedItem;

                // Pasamos 0 porque todavía no se logueó nadie
                TRADUCTOR_BLL.GetInstance().CambiarIdioma(nuevoIdioma, 0);
            }
        }
    }
}
