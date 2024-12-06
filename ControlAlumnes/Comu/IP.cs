using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace ControlAlumnes.Comu
{
    public static class Ip
    {
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
                            
                        var ipInfo = new IpInfo
                        {
                            IpAddress = ip.Address,
                            IpMask = ip.IPv4Mask,
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


        public static List<IpInfo> GetCodisConnexio()
        {
            try
            {
                return !GetIpInfo(out var ipInfos) ? 
                    null : 
                    ipInfos;
            }
            catch (Exception ex)
            {
                ex.Show();
            }

            return null;
        }
    }
}
