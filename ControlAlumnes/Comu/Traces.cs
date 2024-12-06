using System;
using System.Diagnostics;

namespace ControlAlumnes.Comu
{
    public static class Traces
    {
        public enum TipusTraça
        {
            Info,
            Error,
            Debug
        }

        public static void Traça(this TipusTraça tipus, string missatge)
        {
            try
            {
                var msg = $"{DateTime.Now:G} [{tipus}] {missatge}";
                Trace.WriteLine(msg);
            }
            catch
            {
                // ignore
            }
            finally
            {
                Trace.Flush();
            }
        }

        public static void Traça(this TipusTraça tipus, string[] missatges)
        {
            foreach (var missatge in missatges)
                Traça(tipus, missatge);
        }
    }
}
