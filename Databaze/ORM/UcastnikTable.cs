using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejovaLigaORM.Databaze.ORM
{
    class UcastnikTable
    {
        public static string SQL_UPDATE = "UPDATE Ucastnik SET body=@body WHERE idTym = @idTym and idRocnik = @idRocnik";
        public static string SQL_INSERT = "INSERT INTO Ucastnik VALUES (@idTym, @idRocnik, @body)";
        
        public static int Insert(Ucastnik ucast)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, ucast);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        
        public static int Update(Ucastnik ucast, Database pDb = null)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, ucast);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }


        private static void PrepareCommand(SqlCommand command, Ucastnik ucastnik)
        {
            command.Parameters.AddWithValue("@idTym", ucastnik.idTym);
            command.Parameters.AddWithValue("@idRocnik", ucastnik.idRocnik);
            command.Parameters.AddWithValue("@body", ucastnik.body);
        }

        private static Collection<Ucastnik> Read(SqlDataReader reader)
        {
            Collection<Ucastnik> ucasti = new Collection<Ucastnik>();

            while (reader.Read())
            {
                int i = -1;
                Ucastnik ucast = new Ucastnik();
                ucast.idTym = reader.GetString(++i);
                ucast.idRocnik = reader.GetInt32(++i);
                ucast.body = reader.GetInt32(++i);
                ucasti.Add(ucast);
            }
            return ucasti;
        }
    }
}
