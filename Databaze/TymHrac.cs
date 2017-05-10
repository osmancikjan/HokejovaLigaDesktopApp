using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze
{
    public class TymHrac
    {
        public string tym { get; set; }
        public int idHrac { get; set; }
        public DateTime zacatek { get; set; }
        public DateTime? konec { get; set; }
    }
}
