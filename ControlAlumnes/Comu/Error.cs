using System;
using System.Windows.Forms;

namespace ControlAlumnes.Comu
{
    public static class Error
    {
        public static void Show(this Exception ex, bool showStackTrace = true)
        {
            try
            {
                var msg = showStackTrace ? 
                        $"{ex.Message}{Environment.NewLine}{ex.StackTrace}":
                        ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TipusTraça.Error.Traça(ex.Message);
                TipusTraça.Error.Traça(ex.StackTrace.Replace(Environment.NewLine, "^").Split('^'));
            }
            catch
            {
                // ignore
            }
        }
    }
}
