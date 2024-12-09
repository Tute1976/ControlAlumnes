using System;
using System.Net;
using System.Net.NetworkInformation;

namespace ControlAlumnes.Comu
{
    public class IpInfo
    {
        public PhysicalAddress PhysicalAddress { get; set; }
        public IPAddress IpAddress { get; set; }
        public IPAddress IpNetworkAddress { get; set; }
        public IPAddress IpMask { get; set; }
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
                IpAddress = ipAddress;
                IpMask = ipMask;

                var bytesAddress = IpAddress.GetAddressBytes();
                var bytesMask = IpMask.GetAddressBytes();

                var bytesResult = IPAddress.None.GetAddressBytes();
                for (var i = 0; i < 4; i++)
                {
                    var notMask = Convert.ToByte(~bytesMask[i] & 255);
                    bytesResult[i] = Convert.ToByte(bytesAddress[i] & notMask);
                }
                IpNetworkAddress = new IPAddress(bytesResult);

                bytesResult = IPAddress.None.GetAddressBytes();
                for (var i = 0; i < 4; i++)
                {
                    var notMask = Convert.ToByte(bytesMask[i] & 255);
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
