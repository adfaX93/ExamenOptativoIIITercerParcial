
namespace Repository.Data.Cliente
{
    public interface IClienteRepository
    {
        bool add(ClienteModel clienteModel);
        bool update(ClienteModel clienteModel);
        bool delete(int id);
        IEnumerable<ClienteModel> GetAll();
    }
}
