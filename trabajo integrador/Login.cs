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
    public partial class Login : Form, Observer
    {

        USUARIO_BLL usubll = new USUARIO_BLL();
        private bool _soloAdmin;
        private bool _cargandoCombo = true;
        private bool _idiomaCambiadoManualmente = false;
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
                
                if (!(c is TextBox) && !(c is ComboBox))
                {
                    c.Text = TRADUCTOR_BLL.GetInstance().Traducir(c.Name, c.Text);
                }
                if (c.HasChildren) TraducirControles(c.Controls);
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

                
                if (_idiomaCambiadoManualmente)
                {
                    
                    TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaElegido, idUsuarioLogueado);
                }
                else if (usuarioLogueado?.IdIdioma != null)
                {
                    
                    var idiomasDisponibles = TRADUCTOR_BLL.GetInstance().ObtenerIdiomas();
                    var idiomaGuardado = idiomasDisponibles.Find(x => x.IdIdioma == usuarioLogueado.IdIdioma.Value);
                    if (idiomaGuardado != null)
                    {
                        TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaGuardado, idUsuarioLogueado);
                    }
                }
                else
                {
                    
                    TRADUCTOR_BLL.GetInstance().CambiarIdioma(idiomaElegido, idUsuarioLogueado);
                }

                TRADUCTOR_BLL.GetInstance().Eliminar(this); 

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
            btnIniciarSesion.BackColor = Color.Navy;
            btnIniciarSesion.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnIniciarSesion.BackColor = Color.White;
            btnIniciarSesion.ForeColor = Color.Navy;
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
                _idiomaCambiadoManualmente = true; 
                BE.IDIOMA nuevoIdioma = (BE.IDIOMA)cmbIdiomas.SelectedItem;

                
                TRADUCTOR_BLL.GetInstance().CambiarIdioma(nuevoIdioma, 0);
            }
        }
    }
}
