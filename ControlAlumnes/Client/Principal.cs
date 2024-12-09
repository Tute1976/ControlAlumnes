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
                listInfo.Items.Clear();

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
                Enabled = false;

                Sessio.EstacioInfo.Nom = txtNom.Text;

                if (!Ip.GetIpInfo(out var ipInfos))
                    return;
                Sessio.IpInfos = ipInfos;
                foreach (var ipInfo in Sessio.IpInfos)
                {
                    var ipAddress = ipInfo.GetIpSegonsCodi(txtCodi.Text);


                    listInfo.CrearEntradaInfo($"Ping enviat ({ipAddress})");
                    TipusMissatge.Ping.Enviar(ipAddress, Ip.PortServidor, ipInfo);
                }

                Sessio.EstacioInfo.IpInfo.Escolta(true, Missatge);
            }
            catch (Exception ex)
            {
                ex.Show();
                Enabled = true;
            }
        }

        private void Missatge(TipusMissatge tipusMissatge, IPAddress ipAddress, string json)
        {
            try
            {
                listInfo.CrearEntradaInfo($"Missatge rebut --> {tipusMissatge}");

                switch (tipusMissatge)
                {
                    case TipusMissatge.Pong: // Paquet de pong rebut, contestant amb batec ...
                        Sessio.IpAddressServidor = ipAddress;
                        Sessio.EstacioInfo.IpInfo = Sessio.IpInfos.First(i => i.IpAddress.ToString().Equals(json));
                        TimerBatex_Tick(null, null);

                        timerBatex.Enabled = true;
                        timerBatex.Start();
                        break;

                    case TipusMissatge.Inici:
                        if (InvokeRequired)
                            Invoke((Action)Amaga);
                        else
                            Amaga();
                        break;

                    case TipusMissatge.Fi:
                        if (InvokeRequired)
                            Invoke((Action)Mostra);
                        else
                            Mostra();
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

            Amaga();
        }

        private void IconaBarra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Mostra();
        }

        private void Amaga()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Hide();
        }
        private void Mostra()
        {
            ShowInTaskbar = true;
            Show();
        }

        private void TimerBatex_Tick(object sender, EventArgs e)
        {
            try
            {
                listInfo.CrearEntradaInfo($"Batex enviat ({Sessio.IpAddressServidor})");
                TipusMissatge.Batec.Enviar(Sessio.IpAddressServidor, Ip.PortServidor, Sessio.EstacioInfo.IpInfo);
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
