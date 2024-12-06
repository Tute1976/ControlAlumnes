using ControlAlumnes.Comu;
using System;
using System.Windows.Forms;

namespace ControlAlumnes.Control
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmPrincipal());
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
