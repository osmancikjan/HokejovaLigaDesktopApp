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
    class TymTable
    {
        public static string SQL_SELECT = "SELECT * FROM Tym";
        public static string SQL_UPDATE = "UPDATE Tym SET nazev = @nazev WHERE kod = @kod";
       
        public static int Vlozeni(Tym tym)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("VlozeniTymu");
            command.CommandType = CommandType.StoredProcedure;
            PrepareCommand(command, tym);

            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(Tym tym)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, tym);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static int Delete(string kod)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("VymazTym");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@kod", kod);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static Collection<Tym> Select()
        {
            
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = command.ExecuteReader();
            Collection<Tym> tymy = Read(reader);

            db.Close();

            return tymy;
        }

        private static void PrepareCommand(SqlCommand command, Tym tym)
        {
            command.Parameters.AddWithValue("@kod", tym.kod);
            command.Parameters.AddWithValue("@nazev", tym.nazev);
        }

        private static Collection<Tym> Read(SqlDataReader reader)
        {
            Collection<Tym> tymy = new Collection<Tym>();

            while (reader.Read())
            {
                int i = -1;
                Tym tym = new Tym();
                tym.kod = reader.GetString(++i);
                tym.nazev = reader.GetString(++i);
                tymy.Add(tym);
            }
            return tymy;
        }
    }
}
