using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;


namespace trabajo_integrador
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                BLL.InicializacionBLL.PrepararBaseDeDatos();

                var dvBLL = new BLL.DV_BLL();
                var errores = dvBLL.VerificarIntegridad();

                if (errores != null && errores.Count > 0)
                    Application.Run(new Login(soloAdmin: true));
                else
                    Application.Run(new Login(soloAdmin: false));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico de inicialización: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
