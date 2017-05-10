using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HokejovaLigaORM.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form vlozeniKontraktu = new VlozeniKontraktu();
            vlozeniKontraktu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form seznamZapasu = new SeznamZapasu();
            seznamZapasu.Show();
        }
    }
}
