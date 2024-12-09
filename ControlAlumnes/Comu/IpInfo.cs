using System;
using System.Net;

namespace ControlAlumnes.Comu
{
    public class IpInfo
    {
        public string PhysicalAddress { get; set; }
        public string IpAddress { get; set; }
        public string IpNetworkAddress { get; set; }
        public string IpMask { get; set; }
        
        public string AdapterName { get; set; }
        public int Codi { get; set; }
        
        public delegate void MissatgeEventCallback(TipusMissatge tipusMissatge, IPAddress ipAddress, string json);

        private UdpSocket _udpSocket;

        public IpInfo(IPAddress ipAddress, IPAddress ipMask)
        {
            try
            {
                IpAddress = ipAddress.ToString();
                IpMask = ipMask.ToString();
                IpNetworkAddress = ipAddress.CalculaXarxa(ipMask).ToString();

                var ipNode = ipAddress.CalculaNode(ipMask);
                Codi = Convert.ToInt32(ipNode.ToString().Replace(".", ""));
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        public void Escolta(bool enMarxa, MissatgeEventCallback missatgeEvent)
        {
            try
            {
                if (enMarxa)
                {
                    _udpSocket = new UdpSocket();
                    _udpSocket.Server(IpAddress, 20000, missatgeEvent);
                }
                else
                {
                    _udpSocket = null;
                }
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
