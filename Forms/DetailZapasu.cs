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
    public partial class DetailZapasu : Form
    {
        public DetailZapasu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DetailZapasu_Load(object sender, EventArgs e)
        {
            Zapas zapas = ZapasTable.Select(SeznamZapasu.idZapasu);
            domaciL.Text = zapas.domaci;
            hosteL.Text = zapas.hoste;
            score.Text = zapas.skoreD + ":" + zapas.skoreH;
            cas.Text = zapas.datum.ToLongDateString();

            foreach(Hrac s in ZapasTable.Detail(SeznamZapasu.idZapasu, "G"))
            {
                strelciLB.Items.Add(s.prijmeni + " " + s.jmeno + " - " + s.post + " - " + s.cislo);
            }
            foreach (Hrac a in ZapasTable.Detail(SeznamZapasu.idZapasu, "A"))
            {
                asistenceLB.Items.Add(a.prijmeni + " " + a.jmeno + " - " + a.post + " - " + a.cislo);
            }
        }
    }
}
