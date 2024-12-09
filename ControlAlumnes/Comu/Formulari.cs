using System;
using System.Net;
using System.Windows.Forms;

namespace ControlAlumnes.Comu
{
    public static class Formulari
    {
        private static ListViewItem BuscaInvoked(this ListView llista, IPAddress ipAddress)
        {
            foreach (ListViewItem item in llista.Items)
            {
                switch (item.Tag)
                {
                    case null:
                        continue;
                    case EstacioInfo estacioInfo when estacioInfo.IpInfo.IpAddress.Equals(ipAddress):
                        return item;
                }
            }

            return null;
        }

        public static ListViewItem Busca(this ListView llista, IPAddress ipAddress)
        {
            if (llista.InvokeRequired)
            {
                ListViewItem item = null;
                var action = new Action<ListView>(ll => item = ll.BuscaInvoked(ipAddress));
                llista.Invoke(action, llista);
                return item;
            }

            return llista.BuscaInvoked(ipAddress);
        }

        public static void CanviaImatge(this ListView llista, IPAddress ipAddress, int imageIndex)
        {
            var item = llista.Busca(ipAddress);
            if (item == null) 
                return;

            item.ImageIndex = imageIndex;
            item.StateImageIndex = imageIndex;
            item.SubItems[3].Text = DateTime.Now.ToString("G");
        }

        public static void CrearEntrada(this ListView events, string estacio, int imageIndex, string text)
        {
            var item = new ListViewItem(estacio)
            {
                ImageIndex = imageIndex,
                StateImageIndex = imageIndex
            };
            item.SubItems.Add(DateTime.Now.ToString("G"));
            item.SubItems.Add(text);

            if (events.InvokeRequired)
                events.Invoke((Action)(() => events.Items.Insert(0, item)));
            else
                events.Items.Insert(0, item);
        }

        public static void EnumeraTab(this TabPage tab, int numero)
        {
            if (tab.InvokeRequired)
                tab.Invoke((Action)(() => tab.Text = string.Format((string)tab.Tag, numero)));
            else
                tab.Text = string.Format((string)tab.Tag, numero);
        }

        public static void Afegeix(this ListView llista, ListViewItem item, string grup)
        {
            if (llista.InvokeRequired)
                llista.Invoke((Action)(() => llista.Groups[grup].Items.Add(item)));
            else
                llista.Groups[grup].Items.Add(item);
        }

        public static void Actualitza(this ListViewItem item)
        {
            if (item.ListView.InvokeRequired)
                item.ListView.Invoke((Action)(() => item.SubItems[3].Text = DateTime.Now.ToString("G")));
            else
                item.SubItems[3].Text = DateTime.Now.ToString("G");
        }
    }
}
