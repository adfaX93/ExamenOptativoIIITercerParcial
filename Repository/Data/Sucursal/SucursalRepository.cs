using Dapper;
using Repository.Data.ConfiguracionesDB;
using Repository.Data.Sucursal;
using System.Data;

public class SucursalRepository : ISucursalRepository
{
    IDbConnection _connection;

    public SucursalRepository(string connectionString)
    {
        _connection = new ConnetionDB(connectionString).OpenConnection();
    }

    public bool add(SucursalModel sucursalModel)
    {
        throw new NotImplementedException();
    }

    public bool delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SucursalModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool update(SucursalModel sucursalModel)
    {
        throw new NotImplementedException();
    }
}