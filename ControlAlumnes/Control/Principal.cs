using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using ControlAlumnes.Comu;

namespace ControlAlumnes.Control
{
    public partial class FrmPrincipal : Form
    {
        private IEnumerable<IpInfo> IpInfos { get; set; }
        private IpInfo IpInfo { get;set;}
        private Dictionary<IPAddress, EstacioInfo> Estacions {get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                IpInfos = Ip.GetCodisConnexio();
                cbCodi.Items.Clear();

                if (IpInfos == null) 
                    return;

                foreach (var ipInfo in IpInfos)
                    cbCodi.Items.Add($@"{ipInfo.AdapterName} | {ipInfo.IpAddress}");
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
                IpInfo = IpInfos.First(i => i.AdapterName.Equals(adapterName, StringComparison.CurrentCultureIgnoreCase));

                lCodi.Text = $@"{IpInfo.Codi}";
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
                    Estacions = new Dictionary<IPAddress, EstacioInfo>();
                    IpInfo.Escolta(true, Missatge);
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
                        estacioInfo.IpAddress = ipAddress;
                        if (!Estacions.ContainsKey(ipAddress))
                        {
                            var item = new ListViewItem(estacioInfo.Estacio)
                            {
                                ImageIndex = 1,
                                StateImageIndex = 1
                            };
                            item.SubItems.Add(estacioInfo.Usuari);
                            item.SubItems.Add(ipAddress.ToString());
                            item.SubItems.Add(DateTime.Now.ToString("G"));
                            item.Tag = estacioInfo;
                            Estacions.Add(ipAddress, estacioInfo);
                            if (llista.InvokeRequired)
                                llista.Invoke((Action)(() => llista.Items.Add(item)));
                            else
                                llista.Items.Add(item);

                            events.CrearEntrada(estacioInfo.Estacio, 1, "Nova estació registrada");
                        }
                        else
                        {
                            if (llista.InvokeRequired)
                                llista.Invoke((Action)(() => llista.CanviaData(ipAddress)));
                            else
                                llista.CanviaData(ipAddress);
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
                }

            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
