using HokejovaLigaORM.Databaze;
using HokejovaLigaORM.Databaze.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HokejovaLigaORM.Forms
{
    public partial class SeznamZapasu : Form
    {
        public static int idZapasu;
        public SeznamZapasu()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void hledejZapas_Click(object sender, EventArgs e)
        {
            zapasyListBox.Items.Clear();
            DateTime datum = zapasDTP.Value;
            Collection<Zapas> zapasy = ZapasTable.Seznam(datum);
            foreach(Zapas z in zapasy)
            {
                zapasyListBox.Items.Add(z.idZapas + " " + z.domaci + ":" + z.hoste + "\t" + datum + "\t" + z.skoreD + ":" + z.skoreH);
            }
        }

        private void detailZapasu_Click(object sender, EventArgs e)
        {
            string tmp = zapasyListBox.SelectedItem.ToString();
            string[] arr = tmp.Split(' ');
            idZapasu = int.Parse(arr[0]);
            Form detailZapasu = new DetailZapasu();
            detailZapasu.Show();
        }
    }
}
