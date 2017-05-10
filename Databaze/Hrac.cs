using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze
{
    public class Hrac
    {
        public int idHrac { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public int body { get; set; }
        public string post { get; set; }
        public int? cislo { get; set; }
    }
}
