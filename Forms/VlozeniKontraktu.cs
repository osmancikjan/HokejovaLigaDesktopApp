using HokejovaLigaORM.Databaze;
using HokejovaLigaORM.Databaze.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HokejovaLigaORM.Forms
{
    public partial class VlozeniKontraktu : Form
    {
        Collection<Hrac> hraci = new Collection<Hrac>();
        Collection<Tym> tymy = TymTable.Select();

        public VlozeniKontraktu()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TymHrac th = new TymHrac();
            th.tym = "CZ01020300";
            th.idHrac = 31;
            th.zacatek = new DateTime(2017, 4, 27).Date;
            Console.WriteLine(TymHracTable.Insert(th));
        }

        private void VlozeniKontraktu_Load(object sender, EventArgs e)
        {
            foreach(Tym t in tymy)
            {
                tymyCombobox.Items.Add(t.nazev);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hracListBox.Items.Clear();
            string search = hracTextBox.Text;
            hraci = HracTable.Seznam(search);
            foreach(Hrac h in hraci)
            {
                hracListBox.Items.Add(h.idHrac.ToString() + " " + h.jmeno + " " + h.prijmeni + " " + h.cislo.ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string hrac = hracListBox.SelectedItem.ToString();
            string tym = tymyCombobox.SelectedItem.ToString();
            DateTime zacatek = odDTPicker.Value;
            DateTime konec = doDTPicker.Value;

            TymHrac kontrakt = new TymHrac();

            string[] hs = hrac.Split(' ');

            foreach(Tym t in tymy)
            {
                if(t.nazev == tym)
                {
                    kontrakt.tym = t.kod;
                }
            }
            kontrakt.idHrac = int.Parse(hs[0]);
            kontrakt.zacatek = zacatek.Date;
            kontrakt.konec = konec.Date;
            TymHracTable.Insert(kontrakt);
            MessageBox.Show("Kontrakt úspěšně vložen.","Upozornění");
            Close();
        }

        private void hracListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
