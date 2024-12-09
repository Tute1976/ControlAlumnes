using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using ControlAlumnes.Comu;

namespace ControlAlumnes.Control
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
                if(!Ip.GetIpInfo(out var ipInfos))
                    return;
                Sessio.IpInfos = ipInfos;

                cbCodi.Items.Clear();

                foreach (var ipInfo in Sessio.IpInfos)
                    cbCodi.Items.Add($@"{ipInfo.AdapterName} | {ipInfo.IpAddress}");

                if (cbCodi.Items.Count != 1) 
                    return;
                
                cbCodi.SelectedIndex = 0;
                cbCodi.Visible = false;
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }

        private void CbCodi_TextChanged(object sender, EventArgs e)
        {
            if (!cbCodi.Text.Contains("|"))
            {
                lCodi.Text = @"???";
                botoIniciarAturar.Enabled = false;
            }
            else
            {
                var adapterName = cbCodi.Text.Split('|').First().Trim();
                Sessio.EstacioInfo.IpInfo = Sessio.IpInfos.First(i => i.AdapterName.Equals(adapterName, StringComparison.CurrentCultureIgnoreCase));

                lCodi.Text = $@"{Sessio.EstacioInfo.IpInfo.Codi}";
                botoIniciarAturar.Enabled = true;
            }
        }

        private void BotoTancar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Vols finalitzar l'aplicació?", @"Tancar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void BotoIniciarAturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(botoIniciarAturar.Tag is bool b) &&
                    (!(botoIniciarAturar.Tag is string s) || !bool.TryParse(s, out b))) 
                    return;

                if (b)
                {
                    botoIniciarAturar.Tag = false;
                    botoIniciarAturar.Image = Properties.Resources.Media_Play;
                    cbCodi.Enabled = true;
                }
                else
                {
                    botoIniciarAturar.Tag = true;
                    botoIniciarAturar.Image = Properties.Resources.Media_Stop;
                    cbCodi.Enabled = false;

                    llista.Items.Clear();
                    llista.Groups.Add("Connectades", "Estacions connectades");
                    llista.Groups.Add("Desconnectades", "Estacions desconnectades");
                    Sessio.EstacioInfo.IpInfo.Escolta(true, Missatge);
                }

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
                    case TipusMissatge.Batec:
                        var estacioInfo = json.Desserialitzar<EstacioInfo>();
                        var item = llista.Busca(ipAddress);
                        if (item == null)
                        {
                            item = new ListViewItem(estacioInfo.Estacio)
                            {
                                ImageIndex = 1,
                                StateImageIndex = 1
                            };
                            item.SubItems.Add(estacioInfo.Usuari);
                            item.SubItems.Add(ipAddress.ToString());
                            item.SubItems.Add(DateTime.Now.ToString("G"));
                            item.Tag = estacioInfo;
                            llista.Afegeix(item, "Connectades");
                            events.CrearEntrada(estacioInfo.Estacio, 1, "Nova estació registrada");

                            tabEstacions.EnumeraTab(llista.Items.Count);
                            tabEvents.EnumeraTab(events.Items.Count);
                        }
                        else
                        {
                            item.Actualitza();
                        }
                        break;

                    case TipusMissatge.Inici:
                        if (llista.InvokeRequired)
                            llista.Invoke((Action)(() => llista.CanviaImatge(ipAddress, 2)));
                        else
                            llista.CanviaImatge(ipAddress, 1);
                        break;

                    case TipusMissatge.Fi:
                        if (llista.InvokeRequired)
                            llista.Invoke((Action)(() => llista.CanviaImatge(ipAddress, 3)));
                        else
                            llista.CanviaImatge(ipAddress, 2);
                        break;

                    case TipusMissatge.Deteccio:
                        if (llista.InvokeRequired)
                            llista.Invoke((Action)(() => llista.CanviaImatge(ipAddress, 3)));
                        else
                            llista.CanviaImatge(ipAddress, 3);
                        break;

                    case TipusMissatge.Benvinguda:
                        break;
                    case TipusMissatge.Resposta:
                        break;

                    case TipusMissatge.Ping: // Paquet de ping rebut, contestant ...
                        TipusMissatge.Pong.Enviar(ipAddress, Ip.PortClient, ipAddress);
                        break;
                }

            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
