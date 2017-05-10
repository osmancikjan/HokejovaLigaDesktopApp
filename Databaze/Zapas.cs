using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze
{
    public class Zapas
    {
        public int idZapas { get; set; }
        public string domaci { get; set; }
        public string hoste { get; set; }
        public DateTime datum { get; set; }
        public int kolo { get; set; }
        public int? skoreD { get; set; }
        public int? skoreH { get; set; }
    }
}
