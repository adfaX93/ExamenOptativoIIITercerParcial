using Npgsql;

namespace Repository.Data.ConfiguracionesDB
{
    public class ConnetionDB
    {
        private string conexionString;
        public ConnetionDB(string conexionString)
        {
            this.conexionString = conexionString;
        }
        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(conexionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}