using HokejovaLigaORM.Databaze;
using HokejovaLigaORM.Databaze.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HokejovaLigaORM.Databaze.ORM.TrestTable;
using static HokejovaLigaORM.Databaze.ORM.TymHracTable;

namespace HokejovaLigaORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Menu());
        }
    }
}
