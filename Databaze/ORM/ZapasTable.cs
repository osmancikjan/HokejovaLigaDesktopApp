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
    public class ZapasTable
    {
        public static string SQL_UPDATE = "UPDATE Zapas SET domaci=@domaci, hoste=@hoste, datum=@datum, kolo=@kolo, skoreD=@skoreD, skoreH=@skoreH WHERE idZapas = @idZapas";
        public static string SQL_SELECT = "select idZapas, (select t.nazev from Tym t where t.kod = z.domaci) as domaci,(select t1.nazev from Tym t1 where t1.kod = z.hoste) as hoste,skoreD, skoreH, datum, kolo from Zapas z where idZapas = @idZapas";

        public static Zapas Select(int id)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            command.Parameters.AddWithValue("@idZapas", id);

            SqlDataReader reader = command.ExecuteReader();
            Collection<Zapas> zap = Read(reader);

            reader.Close();

            db.Close();

            return zap[0];
        }

        public static int Insert(Zapas zapas)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("VLozeniZapasu");
            command.CommandType = CommandType.StoredProcedure;

            PrepareCommand(command, zapas);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(Zapas zapas)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zapas);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static Collection<Zapas> Seznam(DateTime datum)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("SeznamZapasu");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@parametr", datum);

            SqlDataReader reader = command.ExecuteReader();
            Collection<Zapas> tab = Read(reader);

            reader.Close();

            db.Close();

            return tab;
        }
        
        public static Collection<Hrac> Detail(int idZapas, string typ)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("DetailZapasu");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idZapas", idZapas);
            command.Parameters.AddWithValue("@typ", typ);

            SqlDataReader reader = command.ExecuteReader();
            Collection<Hrac> h = ReadD(reader);

            db.Close();

            return h;
        }
        
        private static void PrepareCommand(SqlCommand command, Zapas zapas)
        {
            command.Parameters.AddWithValue("@idZapas", zapas.idZapas);
            command.Parameters.AddWithValue("@domaci", zapas.domaci);
            command.Parameters.AddWithValue("@hoste", zapas.hoste);
            command.Parameters.AddWithValue("@datum", zapas.datum);
            command.Parameters.AddWithValue("@kolo", zapas.kolo);
            command.Parameters.AddWithValue("@skoreD", zapas.skoreD);
            command.Parameters.AddWithValue("@skoreH", zapas.skoreH);
        }

        private static Collection<Zapas> Read(SqlDataReader reader)
        {
            Collection<Zapas> zapasy = new Collection<Zapas>();

            while (reader.Read())
            {
                int i = -1;
                Zapas zapas = new Zapas();
                zapas.idZapas = reader.GetInt32(++i);
                zapas.domaci = reader.GetString(++i);
                zapas.hoste = reader.GetString(++i);
                zapas.skoreD = reader.GetInt32(++i);
                zapas.skoreH = reader.GetInt32(++i);
                zapas.datum = reader.GetDateTime(++i);
                zapas.kolo = reader.GetInt32(++i);
                
                zapasy.Add(zapas);
            }
            return zapasy;
        }

        private static Collection<Hrac> ReadD(SqlDataReader reader)
        {
            Collection<Hrac> hr = new Collection<Hrac>();

            while (reader.Read())
            {
                int i = -1;
                Hrac h = new Hrac();
                h.cislo = reader.GetInt32(++i);
                h.jmeno = reader.GetString(++i);
                h.prijmeni = reader.GetString(++i);
                h.post = reader.GetString(++i);

                hr.Add(h);
            }
            return hr;
        }
    }
}
