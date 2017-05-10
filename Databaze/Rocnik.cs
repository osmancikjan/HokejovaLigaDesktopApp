using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze
{
    class Rocnik
    {
        public int idRocnik { get; set; }
        public int idLiga { get; set; }
        public string nazev { get; set; }
        public DateTime zacatek { get; set; }
        public DateTime konec { get; set; }
        public int pocetKol { get; set; }
    }
}
