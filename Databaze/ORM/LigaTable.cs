using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze.ORM
{
    public class LigaTable
    {
        public class Tabulka
        {
            public string Tym { get; set; }
            public int GV { get; set; }
            public int GO { get; set; }
            public int body { get; set; }
        }
        public class LigTab
        {
            public int idRocnik { get; set; }
            public string nameRocnik { get; set; }
            public int idLiga { get; set; }
            public string nameLiga { get; set; }
        }
        public static string SQL_INSERT = "INSERT INTO Liga VALUES (@idLiga, @nazev)";
        public static string SQL_UPDATE = "UPDATE Liga SET nazev = @nazev WHERE idLiga=@idLiga";
        
        public static int Insert(Liga liga)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, liga);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(Liga liga)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, liga);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static Collection<Tabulka> DetailLigy(int idRocnik)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("DetailLigy");
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter input = new SqlParameter();
            input.ParameterName = "@idRocnik";
            input.DbType = DbType.Int32;
            input.Value = idRocnik;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);
            
            SqlDataReader reader = command.ExecuteReader();
            Collection<Tabulka> tab = ReadT(reader);
            reader.Close();
            db.Close();
            
            return tab;
        }

        public static Collection<LigTab> SeznamLig()
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("SeznamLig");
            command.CommandType = CommandType.StoredProcedure;

            int ret = db.ExecuteNonQuery(command);
            SqlDataReader reader = command.ExecuteReader();
            Collection<LigTab> tab = ReadL(reader);

            db.Close();

            return tab;
        }

        private static void PrepareCommand(SqlCommand command, Liga liga)
        {
            command.Parameters.AddWithValue("@idLiga", liga.idLiga);
            command.Parameters.AddWithValue("@nazev", liga.nazev);
        }

        private static Collection<Tabulka> ReadT(SqlDataReader reader)
        {
            Collection<Tabulka> tab = new Collection<Tabulka>();

            while (reader.Read())
            {
                int i = -1;
                Tabulka t = new Tabulka();
                t.Tym = reader.GetString(++i);
                t.GV = reader.GetInt32(++i);
                t.GO = reader.GetInt32(++i);
                t.body = reader.GetInt32(++i);
                tab.Add(t);
            }
            return tab;
        }

        private static Collection<LigTab> ReadL(SqlDataReader reader)
        {
            Collection<LigTab> tab = new Collection<LigTab>();
            while (reader.Read())
            {
                int i = -1;
                LigTab t = new LigTab();
                t.idRocnik = reader.GetInt32(++i);
                t.nameRocnik = reader.GetString(++i);
                t.idLiga = reader.GetInt32(++i);
                t.nameLiga = reader.GetString(++i);
                tab.Add(t);
            }
            return tab;
        }
    }
}
