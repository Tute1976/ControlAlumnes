using System;
using System.Linq;
using System.Net;
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

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Ip.GetIpInfo(out var ipInfos))
                    return;
                Sessio.IpInfos = ipInfos;
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        private void Textes_TextChanged(object sender, EventArgs e)
        {
            bConnectar.Enabled = !string.IsNullOrEmpty(txtCodi.Text) && !string.IsNullOrEmpty(txtNom.Text);
        }

        private void BConnectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Ip.GetIpInfo(out var ipInfos))
                    return;
                Sessio.IpInfos = ipInfos;
                foreach (var ipInfo in Sessio.IpInfos)
                {
                    var ipAddress = ipInfo.GetIpSegonsCodi(txtCodi.Text);
                    TipusMissatge.Ping.Enviar(ipAddress, Ip.PortServidor, ipInfo);
                }

                Sessio.IpInfo.Escolta(true, Missatge);
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        private void Missatge(TipusMissatge tipusMissatge, IPAddress ipAddress, string json)
        {
            try
            {
                switch (tipusMissatge)
                {
                    case TipusMissatge.Pong: // Paquet de pong rebut, contestant amb batec ...
                        Sessio.IpAddressServidor = ipAddress;
                        Sessio.IpInfo = Sessio.IpInfos.First(i => i.IpAddress.ToString().Equals(json));
                        TimerBatex_Tick(null, null);

                        timerBatex.Enabled = true;
                        timerBatex.Start();
                        break;

                    case TipusMissatge.Inici:
                        break;

                    case TipusMissatge.Fi:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Sessio.Connectat) 
                return;

            e.Cancel = true;

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Hide();
        }

        private void IconaBarra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            Show();
        }

        private void TimerBatex_Tick(object sender, EventArgs e)
        {
            try
            {
                TipusMissatge.Batec.Enviar(Sessio.IpAddressServidor, Ip.PortServidor, Sessio.IpInfo);
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
