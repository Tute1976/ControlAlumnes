using System;
using System.Windows.Forms;
using ControlAlumnes.Comu;

namespace ControlAlumnes.Client
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var udpSocket = new UdpSocket();
                udpSocket.Client("192.168.3.228", 20000);

                var estacioInfo = new EstacioInfo
                {
                    Estacio = Environment.MachineName,
                    Usuari = Environment.UserName
                };

                udpSocket.Send(TipusMissatge.Batec, estacioInfo.Serialitza());
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
