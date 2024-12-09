using System;
using System.Collections.Generic;
using System.Net;

namespace ControlAlumnes.Comu
{
    public static class Sessio
    {
        public static IEnumerable<IpInfo> IpInfos { get; set; }

        public static EstacioInfo EstacioInfo { get; set; }

        public static IPAddress IpAddressServidor { get; set; }

        public static bool Connectat { get; set; }

        static Sessio()
        {
            EstacioInfo = new EstacioInfo
            {
                Estacio = Environment.MachineName,
                Usuari = Environment.UserName,
                IpInfo = null
            };
        }
    }
}
