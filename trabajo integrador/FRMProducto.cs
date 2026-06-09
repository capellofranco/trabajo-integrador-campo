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
    public partial class FRMProducto : Form, Observer
    {
        BLL.PRODUCTO_BLL gestorProducto = new BLL.PRODUCTO_BLL();

        public FRMProducto()
        {
            InitializeComponent();
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
                // FILTRO CLAVE: Solo traducimos si NO es un control de ingreso de datos
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is NumericUpDown) && !(c is ListBox))
                {
                    c.Text = TRADUCTOR_BLL.GetInstance().Traducir(c.Name, c.Text);
                }

                // Las grillas se traducen aparte por sus columnas
                if (c is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.HeaderText = TRADUCTOR_BLL.GetInstance().Traducir(col.Name, col.HeaderText);
                    }
                }

                // Si tiene paneles o groupbox, entra recursivamente
                if (c.HasChildren)
                {
                    TraducirControles(c.Controls);
                }
            }
        }

        private void FRMProducto_Load(object sender, EventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Agregar(this);
            AgregarLenguaje();
            dgwProductos.DataSource = null;
            dgwProductos.DataSource = gestorProducto.ListarProductos();
            if (dgwProductos.Columns.Contains("ID")) dgwProductos.Columns["ID"].Visible = false;
            if (dgwProductos.Columns.Contains("Activo")) dgwProductos.Columns["Activo"].Visible = false;
        }
        private void FRMProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            TRADUCTOR_BLL.GetInstance().Eliminar(this);
        }
    }
}
