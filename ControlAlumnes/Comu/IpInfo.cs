using System;
using System.Net;

namespace ControlAlumnes.Comu
{
    public class IpInfo
    {
        public IPAddress IpAddress { get; set; }
        public IPAddress IpMask { get; set; }
        public string AdapterName { get; set; }

        public delegate void MissatgeEventCallback(EstacioInfo estacioInfo, string missatge);

        private UdpSocket _udpSocket;

        public double Codi
        {
            get
            {
                var bytesAddress = IpAddress.GetAddressBytes();
                var bytesMask = IpMask.GetAddressBytes();

                var bytesResult = IPAddress.None.GetAddressBytes();

                for (var i = 0; i < 4; i++)
                {
                    var notMask = Convert.ToByte(~bytesMask[i] & 255);
                    bytesResult[i] = Convert.ToByte(bytesAddress[i] & notMask);
                }
                var address = new IPAddress(bytesResult);
                var codi = Convert.ToDouble(address.ToString().Replace(".", ""));

                return codi;
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
