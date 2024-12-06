using System;
using System.Windows.Forms;
using ControlAlumnes.Comu;

namespace ControlAlumnes.Client
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
