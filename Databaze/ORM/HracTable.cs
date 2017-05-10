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
    class HracTable
    {
        public static string DETAIL = "SELECT * FROM Hrac WHERE idHrac = @idHrac";
        public static string SQL_INSERT = "INSERT INTO Hrac VALUES (@idHrac, @jmeno, @prijmeni, @body, @post, @cislo)";
        public static string SQL_UPDATE = "UPDATE Hrac SET jmeno = @jmeno, prijmeni=@prijmeni, post=@post, cislo=@cislo WHERE idHrac=@idHrac";
        
        public static int Insert(Hrac hrac)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, hrac);
            int ret = db.ExecuteNonQuery(command);
    
            db.Close();

            return ret;
        }
        
        public static int Update(Hrac hrac)
        {
            Database db;
                        
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, hrac);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            
            return ret;
        }
        
        public static Collection<Hrac> Seznam(string param)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("SeznamHracu");
            command.CommandType = CommandType.StoredProcedure;
            if (!param.Equals(""))
            {
                command.Parameters.AddWithValue("@parametr", param);
            }
            
            SqlDataReader reader = db.Select(command);

            Collection<Hrac> hraci = Read(reader);
            reader.Close();

            db.Close();

            return hraci;
        }
        
        public static Collection<Hrac> Detail(int idHrac)
        {
            Database db;
            db = new Database();
            db.Connect();      

            SqlCommand command = db.CreateCommand(DETAIL);
            PrepareCommandID(command, idHrac);
            SqlDataReader reader = db.Select(command);
            
            Collection<Hrac> hraci = Read(reader);
            reader.Close();

            db.Close();

            return hraci;
        }

        private static void PrepareCommand(SqlCommand command, Hrac Hrac)
        {
            command.Parameters.AddWithValue("@idHrac", Hrac.idHrac);
            command.Parameters.AddWithValue("@jmeno", Hrac.jmeno);
            command.Parameters.AddWithValue("@prijmeni", Hrac.prijmeni);
            command.Parameters.AddWithValue("@body", Hrac.body);
            command.Parameters.AddWithValue("@post", Hrac.post == null ? DBNull.Value : (object)Hrac.post);
            command.Parameters.AddWithValue("@cislo", Hrac.cislo == null ? DBNull.Value : (object)Hrac.cislo);
        }

        private static void PrepareCommandID(SqlCommand command, int idHrac)
        {
            command.Parameters.AddWithValue("@idHrac", idHrac);
        }

        private static void PrepareCommandP(SqlCommand command, string param)
        {
            command.Parameters.AddWithValue("@parametr", param);
        }
        private static Collection<Hrac> Read(SqlDataReader reader)
        {
            Collection<Hrac> hraci = new Collection<Hrac>();

            while (reader.Read())
            {
                int i = -1;
                Hrac hrac = new Hrac();
                hrac.idHrac = reader.GetInt32(++i);
                hrac.jmeno = reader.GetString(++i);
                hrac.prijmeni = reader.GetString(++i);
                hrac.body = reader.GetInt32(++i);
                hrac.post = reader.GetString(++i);
                hrac.cislo = reader.GetInt32(++i);
                hraci.Add(hrac);
            }
            return hraci;
        }
    }
}
