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
    public partial class FRMGestionRoles : Form
    {
        private ACCESO_BLL _accesoBLL = new ACCESO_BLL();
        private USUARIO_BLL _usuarioBLL = new USUARIO_BLL();

        public FRMGestionRoles()
        {
            InitializeComponent();
        }

        
        

        private void btnQuitarSubRol_Click_1(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem == null || cmbRolPadre.SelectedItem == null || cmbRolHijo.SelectedItem == null) return;

            int idUsuario;
            if (!int.TryParse(cmbUsuario.SelectedValue.ToString(), out idUsuario)) return;

            try
            {
                _accesoBLL.QuitarSubRolDeUsuario(
                    idUsuario,
                    (int)cmbRolPadre.SelectedValue,
                    (int)cmbRolHijo.SelectedValue);
                MessageBox.Show("Sub-rol quitado.");
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void FRMGestionRoles_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarArbolUsuario();
            RefrescarPermisosDirectos();
        }

        private void RefrescarPermisosDirectos()
        {
            if (cmbUsuario.SelectedItem == null) return;
            if (cmbUsuario.SelectedValue == null) return;

            int idUsuario;
            if (!int.TryParse(cmbUsuario.SelectedValue.ToString(), out idUsuario)) return;

            var directos = _accesoBLL.ListarPermisosDirectosDeUsuario(idUsuario);
            lstPermisosDirectos.DataSource = null;
            lstPermisosDirectos.DataSource = directos;
            lstPermisosDirectos.DisplayMember = "Nombre";
        }

        private void CargarArbolUsuario()
        {
            treeViewRoles.Nodes.Clear();
            if (cmbUsuario.SelectedItem == null) return;
            if (cmbUsuario.SelectedValue == null) return;

            int idUsuario;
            if (!int.TryParse(cmbUsuario.SelectedValue.ToString(), out idUsuario)) return;

            
            var arboles = _accesoBLL.ObtenerArbolDeUsuario(idUsuario);
            foreach (var rol in arboles)
                treeViewRoles.Nodes.Add(CrearNodoRecursivo(rol));

            
            var directos = _accesoBLL.ListarPermisosDirectosDeUsuario(idUsuario);
            foreach (var permiso in directos)
                treeViewRoles.Nodes.Add(new TreeNode(permiso.Nombre));

            treeViewRoles.ExpandAll();
        }

        private TreeNode CrearNodoRecursivo(BE.ComponenteAcceso componente)
        {
            TreeNode nodo = new TreeNode(componente.Nombre);
            if (componente is BE.ROL rol)
                foreach (var hijo in rol.Hijos)
                    nodo.Nodes.Add(CrearNodoRecursivo(hijo)); 
            return nodo;
        }

        private void CargarCombos()
        {
            var roles = _accesoBLL.ListarRoles();
            var permisos = _accesoBLL.ListarTodosLosPermisos();
            var usuarios = _usuarioBLL.ListarUsuarios();

            // Rol para asignar permiso
            cmbRolParaPermiso.DataSource = new List<BE.ROL>(roles);
            cmbRolParaPermiso.DisplayMember = "Nombre";
            cmbRolParaPermiso.ValueMember = "IdRol";

            // Permiso disponible
            cmbPermiso.DataSource = new List<BE.PERMISO>(permisos);
            cmbPermiso.DisplayMember = "Nombre";
            cmbPermiso.ValueMember = "IdPermiso";

            // Rol padre / hijo para composite
            cmbRolPadre.DataSource = new List<BE.ROL>(roles);
            cmbRolPadre.DisplayMember = "Nombre";
            cmbRolPadre.ValueMember = "IdRol";

            cmbRolHijo.DataSource = new List<BE.ROL>(roles);
            cmbRolHijo.DisplayMember = "Nombre";
            cmbRolHijo.ValueMember = "IdRol";

            // Usuario (compartido para todas las secciones)
            cmbUsuario.DataSource = new List<BE.USUARIO>(usuarios);
            cmbUsuario.DisplayMember = "Username";
            cmbUsuario.ValueMember = "Id";

            // Rol para asignar a usuario
            cmbRolUsuario.DataSource = new List<BE.ROL>(roles);
            cmbRolUsuario.DisplayMember = "Nombre";
            cmbRolUsuario.ValueMember = "IdRol";

            // Permiso directo
            cmbPermisoDirecto.DataSource = new List<BE.PERMISO>(permisos);
            cmbPermisoDirecto.DisplayMember = "Nombre";
            cmbPermisoDirecto.ValueMember = "IdPermiso";
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreRol.Text.Trim();
            string desc = txtDescRol.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresá un nombre para el rol.");
                return;
            }
            try
            {
                _accesoBLL.CrearRol(nombre, desc);
                MessageBox.Show($"Rol '{nombre}' creado correctamente.");
                txtNombreRol.Clear();
                txtDescRol.Clear();
                CargarCombos();
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (cmbRolParaPermiso.SelectedItem == null || cmbPermiso.SelectedItem == null) return;
            try
            {
                _accesoBLL.AgregarPermisoARol(
                    (int)cmbRolParaPermiso.SelectedValue,
                    (int)cmbPermiso.SelectedValue);
                MessageBox.Show("Permiso agregado al rol.");
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            if (cmbRolParaPermiso.SelectedItem == null || cmbPermiso.SelectedItem == null) return;
            try
            {
                _accesoBLL.QuitarPermisoDeRol(
                    (int)cmbRolParaPermiso.SelectedValue,
                    (int)cmbPermiso.SelectedValue);
                MessageBox.Show("Permiso quitado del rol.");
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnAgregarSubRol_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem == null || cmbRolPadre.SelectedItem == null || cmbRolHijo.SelectedItem == null) return;

            int idUsuario;
            if (!int.TryParse(cmbUsuario.SelectedValue.ToString(), out idUsuario)) return;

            try
            {
                _accesoBLL.AgregarSubRolAUsuario(
                    idUsuario,
                    (int)cmbRolPadre.SelectedValue,
                    (int)cmbRolHijo.SelectedValue);
                MessageBox.Show("Sub-rol agregado.");
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnAsignarRol_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem == null || cmbRolUsuario.SelectedItem == null) return;
            try
            {
                _accesoBLL.AsignarRolAUsuario(
                    (int)cmbUsuario.SelectedValue,
                    (int)cmbRolUsuario.SelectedValue);
                MessageBox.Show("Rol asignado al usuario.");
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem == null || cmbRolUsuario.SelectedItem == null) return;
            try
            {
                _accesoBLL.QuitarRolDeUsuario(
                    (int)cmbUsuario.SelectedValue,
                    (int)cmbRolUsuario.SelectedValue);
                MessageBox.Show("Rol quitado del usuario.");
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnAgregarPermisoDirecto_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem == null || cmbPermisoDirecto.SelectedItem == null) return;
            try
            {
                _accesoBLL.AgregarPermisoAUsuario(
                    (int)cmbUsuario.SelectedValue,
                    (int)cmbPermisoDirecto.SelectedValue);
                MessageBox.Show("Permiso directo agregado.");
                RefrescarPermisosDirectos();
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnQuitarPermisoDirecto_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem == null || cmbPermisoDirecto.SelectedItem == null) return;
            try
            {
                _accesoBLL.QuitarPermisoAUsuario(
                    (int)cmbUsuario.SelectedValue,
                    (int)cmbPermisoDirecto.SelectedValue);
                MessageBox.Show("Permiso directo quitado.");
                RefrescarPermisosDirectos();
                CargarArbolUsuario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
