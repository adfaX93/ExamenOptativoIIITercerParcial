using Npgsql;

namespace Repository.Data.ConfiguracionesDB
{
    public class ConexionDB
    {
        private string conexionString;
        public ConexionDB(string conexionString)
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