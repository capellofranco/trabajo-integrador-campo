using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var dvBLL = new BLL.DV_BLL();
            var errores = dvBLL.VerificarIntegridad();

            if (errores.Count > 0)
            {
                string mensaje = "⚠️ Se detectaron problemas de integridad en la base de datos:\n\n"
                               + string.Join("\n", errores)
                               + "\n\nSolo el Administrador puede ingresar al sistema.";

                Login loginRestringido = new Login(soloAdmin: true);
                loginRestringido.Show();
                MessageBox.Show(loginRestringido, mensaje, "Error de integridad",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Run(loginRestringido);
            }
            else
            {
                Application.Run(new Login(soloAdmin: false));
            }
        }
    }
}
