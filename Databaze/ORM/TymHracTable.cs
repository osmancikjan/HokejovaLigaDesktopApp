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
    public class TymHracTable
    {
        public class Kontrakt
        {
            public int id { get; set; }
            public string jmeno { get; set; }
            public string prijmeni { get; set; }
            public int cislo { get; set; }
            public string tym { get; set; }
        }
        public static string SQL_UPDATE = "UPDATE TymHrac SET zacatek = @zacatek, konec = @konec WHERE idHrac = @idHrac AND tym = @tym";
        
        public static int Insert(TymHrac kontrakt)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("PridaniKontraktu");
            command.CommandType = CommandType.StoredProcedure;
            PrepareCommand(command, kontrakt);

            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(TymHrac kontrakt)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, kontrakt);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static Collection<Kontrakt> Seznam(string param)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("SeznamKontraktu");
            command.CommandType = CommandType.StoredProcedure;
            if (!param.Equals(""))
            {
                command.Parameters.AddWithValue("@parametr", param);
            }
            
            SqlDataReader reader = command.ExecuteReader();

            Collection<Kontrakt> ret = Read(reader);
            reader.Close();

            db.Close();

            return ret;
        }
        private static void PrepareCommand(SqlCommand command, TymHrac kontrakt)
        {
            command.Parameters.AddWithValue("@tym", kontrakt.tym);
            command.Parameters.AddWithValue("@idHrac", kontrakt.idHrac);
            command.Parameters.AddWithValue("@zacatek", kontrakt.zacatek);
            command.Parameters.AddWithValue("@konec", kontrakt.konec);
        }

        private static Collection<Kontrakt> Read(SqlDataReader reader)
        {
            Collection<Kontrakt> kontrakty = new Collection<Kontrakt>();

            while (reader.Read())
            {
                int i = -1;
                Kontrakt kontrakt = new Kontrakt();
                kontrakt.id = reader.GetInt32(++i);
                kontrakt.jmeno = reader.GetString(++i);
                kontrakt.prijmeni = reader.GetString(++i);
                kontrakt.cislo = reader.GetInt32(++i);
                kontrakt.tym = reader.GetString(++i);
                kontrakty.Add(kontrakt);
            }
            return kontrakty;
        }
    }
}
