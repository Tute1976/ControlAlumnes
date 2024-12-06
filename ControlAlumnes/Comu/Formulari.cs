using System;
using System.Net;
using System.Windows.Forms;

namespace ControlAlumnes.Comu
{
    public static class Formulari
    {
        private static ListViewItem Busca(this ListView llista, IPAddress ipAddress)
        {
            foreach (ListViewItem item in llista.Items)
            {
                switch (item.Tag)
                {
                    case null:
                        continue;
                    case EstacioInfo estacioInfo when estacioInfo.IpAddress.Equals(ipAddress):
                        return item;
                }
            }

            return null;
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

        public static void CanviaData(this ListView llista, IPAddress ipAddress)
        {
            var item = llista.Busca(ipAddress);
            if (item == null)
                return;

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
    }
}
