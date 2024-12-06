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

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                var udpSocket = new UdpSocket();
                udpSocket.Client("192.168.3.228", 20000);
                udpSocket.Send($@"{Environment.MachineName}|{Environment.UserName}|Hola");
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
