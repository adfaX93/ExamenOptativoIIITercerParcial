using Dapper;
using Repository.Data.ConfiguracionesDB;
using Repository.Data.Sucursal;
using System.Collections.Generic;
using System.Data;

namespace Repository.Data.Sucursal
{
    public class SucursalRepository : ISucursalRepository
    {
        IDbConnection connection;

        public SucursalRepository(string connectionString)
        {
            connection = new ConnetionDB(connectionString).OpenConnection();
        }

        public bool add(SucursalModel sucursalModel)
        {
            try
            {
                connection.Execute("INSERT INTO Sucursal(Descripcion, Direccion, Telefono, Whatsapp, Mail, Estado) " +
                           "VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)", sucursalModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Sucursal WHERE Id = {id}");
            return true;
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            return connection.Query<SucursalModel>("SELECT * FROM Sucursal");
        }

        public bool update(SucursalModel sucursalModel)
        {
            try
            {
                connection.Execute("UPDATE Sucursal SET " +
                           "Descripcion = @Descripcion, " +
                           "Direccion = @Direccion, " +
                           "Telefono = @Telefono, " +
                           "Whatsapp = @Whatsapp, " +
                           "Mail = @Mail, " +
                           "Estado = @Estado " +
                           "WHERE Id = @Id", sucursalModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}