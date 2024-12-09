using System;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ControlAlumnes.Comu
{
    public class UdpSocket
    {
        private readonly Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int BufSize = 8 * 1024;
        private readonly State _state = new State();
        private EndPoint _epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback _recv;
        private IpInfo.MissatgeEventCallback _missatgeEvent;

        private class State
        {
            public readonly byte[] Buffer = new byte[BufSize];
        }

        public void Server(string address, int port, IpInfo.MissatgeEventCallback missatgeEvent)
        {
            try
            {
                Server(IPAddress.Parse(address), port, missatgeEvent);
            }
            catch (Exception ex)
            {
                ex.Show();
            }

        }

        public void Server(IPAddress address, int port, IpInfo.MissatgeEventCallback missatgeEvent)
        {
            try
            {
                _missatgeEvent = missatgeEvent;

                _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                _socket.Bind(new IPEndPoint(address, port));
                Receive();
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        public void Client(IPAddress address, int port)
        {
            try
            {
                _socket.Connect(address, port);
                Receive();
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        public void Send(TipusMissatge tipusMissatge, string json)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes($"{tipusMissatge}|{json}");
                _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
                {
                    _socket.EndSend(ar);
                }, _state);
            }
            catch (Exception ex)
            {
                ex.Show();
            }

        }

        private void Receive()
        {
            try
            {
                _socket.BeginReceiveFrom(_state.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv = (ar) =>
                {
                    var so = (State)ar.AsyncState;
                    var bytes = _socket.EndReceiveFrom(ar, ref _epFrom);
                    _socket.BeginReceiveFrom(so.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv, so);

                    var ipEndPoint = (IPEndPoint)_epFrom;
                    var missatge = Encoding.UTF8.GetString(so.Buffer, 0, bytes);

                    var mm = missatge.Split('|');

                    if (Enum.TryParse(mm.First(), true, out TipusMissatge tipusMissatge))
                        _missatgeEvent?.Invoke(tipusMissatge, ipEndPoint.Address, mm.Last());


                }, _state);
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
