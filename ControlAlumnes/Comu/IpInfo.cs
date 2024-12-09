using System;
using System.Net;
using System.Net.NetworkInformation;

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

        public IpInfo()
        {

        }

        public IpInfo(IPAddress ipAddress, IPAddress ipMask)
        {
            try
            {
                IpAddress = ipAddress.ToString();
                IpMask = ipMask.ToString();

                var bytesAddress = ipAddress.GetAddressBytes();
                var bytesMask = ipMask.GetAddressBytes();

                var bytesResult = IPAddress.None.GetAddressBytes();
                for (var i = 0; i < 4; i++)
                {
                    var notMask = Convert.ToByte(bytesMask[i] & 255);
                    bytesResult[i] = Convert.ToByte(bytesAddress[i] & notMask);
                }
                IpNetworkAddress = new IPAddress(bytesResult).ToString();

                bytesResult = IPAddress.None.GetAddressBytes();
                for (var i = 0; i < 4; i++)
                {
                    var notMask = Convert.ToByte(~bytesMask[i] & 255);
                    bytesResult[i] = Convert.ToByte(bytesAddress[i] & notMask);
                }
                var address = new IPAddress(bytesResult);
                Codi = Convert.ToInt32(address.ToString().Replace(".", ""));
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
