using System.Data;
using System.Data.SqlClient;

namespace HokejovaLigaORM.Databaze.ORM //VlozeniBodovani (@idZapas INTEGER, @idHrac INTEGER, @typ CHAR)
{
    class BodovaniTable
    {
        public static string SQL_UPDATE = "UPDATE Bodovani SET idZapas=@idZapas, idHrac=@idHrac, typ=@typ WHERE idZaznam=@idZaznam";
        
        public static int Insert(Bodovani bod)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("VlozeniBodovani");
            command.CommandType = CommandType.StoredProcedure;
            PrepareCommand(command, bod);
            
            int r = command.ExecuteNonQuery();

            db.Close();

            return r;
        }
        
        public static int Update(int idZaznam, int idZapas, int idHrac, string typ)
        {
            Database db;
            db = new Database();
            db.Connect();
           
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand1(command, idZaznam, idZapas, idHrac, typ);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Bodovani bod)
        {
            command.Parameters.AddWithValue("@idZapas", bod.idZapas);
            command.Parameters.AddWithValue("@idHrac", bod.idHrac);
            command.Parameters.AddWithValue("@typ", bod.typ);
        }

        private static void PrepareCommand1(SqlCommand command, int idZaznam, int idZapas, int idHrac, string typ)
        {
            command.Parameters.AddWithValue("@idZaznam", idZaznam);
            command.Parameters.AddWithValue("@idZapas", idZapas);
            command.Parameters.AddWithValue("@idHrac", idHrac);
            command.Parameters.AddWithValue("@typ", typ);
        }
    }
}
