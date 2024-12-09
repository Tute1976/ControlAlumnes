using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace ControlAlumnes.Comu
{
    public static class Ip
    {
        public static int PortServidor => Properties.Settings.Default.Port_Servidor;
        public static int PortClient => Properties.Settings.Default.Port_Client;

        public static bool GetIpInfo(out List<IpInfo> ipInfos)
        {
            ipInfos = new List<IpInfo>();

            try
            {
                var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                if (networkInterfaces.Length < 1)
                    return false;

                foreach (var networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Down)
                        continue;
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                        continue;
                    if (!networkInterface.Supports(NetworkInterfaceComponent.IPv4))
                        continue;
                    if (networkInterface.Description.Contains("VirtualBox"))
                        continue;
                    if (networkInterface.Description.Contains("VMware"))
                        continue;
                    if (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Wireless80211 &&
                        networkInterface.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
                        continue;

                    foreach (var ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                            continue;

                        var ipInfo = new IpInfo(ip.Address, ip.IPv4Mask)
                        {
                            PhysicalAddress = networkInterface.GetPhysicalAddress().ToString(),
                            AdapterName = networkInterface.Name
                        };
                        ipInfos.Add(ipInfo);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ex.Show();
            }

            return false;
        }

        public static IPAddress GetIpSegonsCodi(this IpInfo ipInfo, string codi)
        {
            var codiPle = codi.PadLeft(12, '0');
            var ipCodiPle = $"{codiPle.Substring(0,3)}.{codiPle.Substring(3, 3)}.{codiPle.Substring(6, 3)}.{codiPle.Substring(9, 3)}";
            var ipAddressCodi = IPAddress.Parse(ipCodiPle);
            var bytesIpAddressCodi = ipAddressCodi.GetAddressBytes();
            var bytesNetworkAddress = IPAddress.Parse(ipInfo.IpNetworkAddress).GetAddressBytes();

            var bytesResult = IPAddress.None.GetAddressBytes();

            for (var i = 0; i < 4; i++)
                bytesResult[i] = Convert.ToByte(bytesIpAddressCodi[i] | bytesNetworkAddress[i]);

            var address = new IPAddress(bytesResult);
            return address;
        }

        private static void Enviar(this TipusMissatge tipusMissatge, IPAddress ipAddress, int port, string json)
        {
            TipusTraça.Info.Traça($"Enviant missatge de tipus '{tipusMissatge}' a {ipAddress}:{port}");

            var udpSocket = new UdpSocket();
            udpSocket.Client(ipAddress, port);
            udpSocket.Send(tipusMissatge, json);
        }

        public static void Enviar(this TipusMissatge tipusMissatge, IPAddress ipAddress, int port, IpInfo ipInfo)
        {
            var json = "";
            if (ipInfo != null)
            {
                Sessio.EstacioInfo.IpInfo = ipInfo;
                json = Sessio.EstacioInfo.Serialitza();
            }
            tipusMissatge.Enviar(ipAddress, port, json);
        }

        public static void Enviar(this TipusMissatge tipusMissatge, IPAddress ipAddress, int port, IPAddress ipAddressServidor)
        {
            var json = ipAddressServidor.ToString().Serialitza();
            tipusMissatge.Enviar(ipAddress, port, json);
        }
    }
}
