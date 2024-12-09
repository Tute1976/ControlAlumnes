using System.Collections.Generic;
using System.Net;

namespace ControlAlumnes.Comu
{
    public static class Sessio
    {
        public static IEnumerable<IpInfo> IpInfos { get; set; }
        public static IpInfo IpInfo { get; set; }
        public static IPAddress IpAddressServidor { get; set; }

        public static bool Connectat { get; set; }
    }
}
