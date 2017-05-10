using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze
{
    public class Trest
    {
        public int idTrest { get; set; }
        public int idHrac { get; set; }
        public DateTime zacatek { get; set; }
        public DateTime konec { get; set; }
    }
}
