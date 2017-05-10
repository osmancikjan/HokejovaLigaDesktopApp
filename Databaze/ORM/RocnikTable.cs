using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze.ORM
{
    class RocnikTable
    {
        public static string SQL_UPDATE = "UPDATE Rocnik SET idLiga = @idLiga, nazev = @nazev, zacatek = @zacatek, konec = @konec, pocetKol = @pocetKol WHERE idRocnik = @idRocnik";
        public static string SQL_INSERT = "INSERT INTO Rocnik VALUES (@idRocnik, @idLiga, @nazev, @zacatek, @konec, @pocetKol)";
       
        public static int Insert(Rocnik rocnik)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, rocnik);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(Rocnik rocnik)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, rocnik);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        private static void PrepareCommand(SqlCommand command, Rocnik rocnik)
        {
            command.Parameters.AddWithValue("@idRocnik", rocnik.idRocnik);
            command.Parameters.AddWithValue("@idLiga", rocnik.idLiga);
            command.Parameters.AddWithValue("@nazev", rocnik.nazev);
            command.Parameters.AddWithValue("@zacatek", rocnik.zacatek);
            command.Parameters.AddWithValue("@konec", rocnik.konec);
            command.Parameters.AddWithValue("@pocetKol", rocnik.pocetKol);
        }
    }
}
