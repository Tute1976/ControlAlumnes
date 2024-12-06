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

        private void FrmPrincipal_Load(object sender, System.EventArgs e)
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
                    botoIniciarAturar.Image = global::ControlAlumnes.Control.Properties.Resources.Media_Play;
                    cbCodi.Enabled = true;
                }
                else
                {
                    botoIniciarAturar.Tag = true;
                    botoIniciarAturar.Image = global::ControlAlumnes.Control.Properties.Resources.Media_Stop;
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

        private void Missatge(EstacioInfo estacioInfo, string missatge)
        {
            try
            {
                if (!Estacions.ContainsKey(estacioInfo.IpAddress))
                {
                    var item = llista.Items.Add(estacioInfo.Estacio, estacioInfo.Estacio, 1);
                    item.SubItems.Add(estacioInfo.Usuari);
                    item.SubItems.Add(estacioInfo.IpAddress.ToString());
                    item.SubItems.Add(DateTime.Now.ToString("G"));
                    item.Tag = estacioInfo;
                    Estacions.Add(estacioInfo.IpAddress, estacioInfo);
                }
                else
                {
                    var item = llista.Items[estacioInfo.Estacio];
                    item.SubItems[3].Text = DateTime.Now.ToString("G");
                }
            }
            catch (Exception ex)
            {
                ex.Show();
            }
        }
    }
}
