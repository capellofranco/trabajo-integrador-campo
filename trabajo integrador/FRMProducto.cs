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
    public partial class FRMProducto : Form
    {
        BLL.PRODUCTO_BLL gestorProducto = new BLL.PRODUCTO_BLL();

        public FRMProducto()
        {
            InitializeComponent();
        }

        private void FRMProducto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestorProducto.ListarProductos();
            if (dataGridView1.Columns.Contains("ID")) dataGridView1.Columns["ID"].Visible = false;
            if (dataGridView1.Columns.Contains("Activo")) dataGridView1.Columns["Activo"].Visible = false;
        }
    }
}
