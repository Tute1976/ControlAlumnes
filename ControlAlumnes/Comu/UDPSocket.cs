using System;
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
            Server(IPAddress.Parse(address), port, missatgeEvent);
        }

        public void Server(IPAddress address, int port, IpInfo.MissatgeEventCallback missatgeEvent)
        {
            _missatgeEvent = missatgeEvent;

            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            _socket.Bind(new IPEndPoint(address, port));
            Receive();
        }

        public void Client(string address, int port)
        {
            _socket.Connect(IPAddress.Parse(address), port);
            Receive();
        }

        public void Send(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);
            _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                _socket.EndSend(ar);
            }, _state);
        }

        private void Receive()
        {
            _socket.BeginReceiveFrom(_state.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv = (ar) =>
            {
                var so = (State)ar.AsyncState;
                var bytes = _socket.EndReceiveFrom(ar, ref _epFrom);
                _socket.BeginReceiveFrom(so.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv, so);

                var ipEndPoint = (IPEndPoint)_epFrom;
                var missatge = Encoding.ASCII.GetString(so.Buffer, 0, bytes);
                var mm = missatge.Split('|');

                var estacioInfo = new EstacioInfo
                {
                    IpAddress = ipEndPoint.Address,
                    Estacio = mm[0],
                    Usuari = mm[1]
                };

                _missatgeEvent?.Invoke(estacioInfo, mm[2]);

            }, _state);
        }
    }
}
