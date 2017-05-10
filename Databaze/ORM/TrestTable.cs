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
    public class TrestTable
    {
        public class SeznamTrestu
        {
            public int idHrac { get; set; }
            public string jmeno { get; set; }
            public string prijmeni { get; set; }
            public int body { get; set; }
            public string post { get; set; }
            public int cislo { get; set; }
            public DateTime zacatek { get; set; }
            public DateTime konec { get; set; }
        }

        public static string SQL_UPDATE = "UPDATE Trest SET idHrac = @idHrac, zacatek = @zacatek, konec = @konec WHERE idTrest = @idTrest";
        public static string SQL_INSERT = "INSERT INTO Trest VALUES (@idTrest, @idHrac, @zacatek, @konec)";
        
        public static int Insert(Trest trest)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, trest);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(Trest trest)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, trest);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static Collection<SeznamTrestu> Seznam()
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("SeznamTrestu");
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            Collection<SeznamTrestu> tresty = Read(reader);

            reader.Close();

            db.Close();

            return tresty;
        }

        public static Collection<SeznamTrestu> Detail(string parametr)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("DetailTrestu");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@parametr", parametr);

            SqlDataReader reader = command.ExecuteReader();
            Collection<SeznamTrestu> tresty = Read(reader);
            reader.Close();
            db.Close();

            return tresty;
        }

        private static void PrepareCommand(SqlCommand command, Trest trest)
        {
            command.Parameters.AddWithValue("@idTrest", trest.idTrest);
            command.Parameters.AddWithValue("@idHrac", trest.idHrac);
            command.Parameters.AddWithValue("@zacatek", trest.zacatek);
            command.Parameters.AddWithValue("@konec", trest.konec);
        }

        private static Collection<SeznamTrestu> Read(SqlDataReader reader)
        {
            Collection<SeznamTrestu> tresty = new Collection<SeznamTrestu>();

            while (reader.Read())
            {
                int i = -1;
                SeznamTrestu trest = new SeznamTrestu();
                trest.idHrac = reader.GetInt32(++i);
                trest.jmeno = reader.GetString(++i);
                trest.prijmeni = reader.GetString(++i);
                trest.body = reader.GetInt32(++i);
                trest.post = reader.GetString(++i);
                trest.cislo = reader.GetInt32(++i);
                trest.zacatek = reader.GetDateTime(++i);
                trest.konec = reader.GetDateTime(++i);
                tresty.Add(trest);
            }
            return tresty;
        }
    }
}
