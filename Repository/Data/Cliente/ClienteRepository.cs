


using Dapper;
using Repository.Data.ConfiguracionesDB;
using Repository.Data.Sucursal;
using System.Data;

namespace Repository.Data.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        IDbConnection connection;
        public ClienteRepository(string connectionString)
        {   
            connection = new ConnetionDB(connectionString).OpenConnection();
        }
        public bool add(ClienteModel clienteModel)
        {
            try
            {
                connection.Execute("INSERT INTO Cliente(Id_Banco, Nombre, Apellido, Documento, Direccion, Mail, Celular, Estado) " +
                           "VALUES (@Id_Banco, @Nombre, @Apellido, @Documento, @Direccion, @Mail, @Celular, @Estado)", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Cliente WHERE Id = {id}");
            return true;
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return connection.Query<ClienteModel>("SELECT * FROM Cliente");
        }

        public bool update(ClienteModel clienteModel)
        {
            try
            {
                connection.Execute("UPDATE Cliente SET " +
                           "Id_Banco = @Id_Banco, " +
                           "Nombre = @Nombre, " +
                           "Apellido = @Apellido, " +
                           "Documento = @Documento, " +
                           "Direccion = @Direccion, " +
                           "Mail = @Mail, " +
                           "Celular = @Celular " +
                           "Estado = @Estado " +
                           "WHERE Id = @Id", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
