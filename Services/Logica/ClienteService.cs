using Repository.Data.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService : IClienteRepository
    {
        private ClienteRepository _repository;
        public ClienteService(string connectionString)
        {
            _repository = new ClienteRepository(connectionString);
        }
        public bool add(ClienteModel clienteModel)
        {
            return validarDatos(clienteModel) ? _repository.add(clienteModel) : throw new Exception("Error en la validacion de datos");
        }

        public bool delete(int id)
        {
            return id > 0 ? _repository.delete(id) : false;
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return _repository.GetAll();
        }

        public bool update(ClienteModel clienteModel)
        {
            return validarDatos(clienteModel) ? _repository.update(clienteModel) : throw new Exception("Error en la validacion de datos");
        }

        private bool validarDatos(ClienteModel cliente)
        {
            if (cliente == null)
                return false;
            if(string.IsNullOrEmpty(cliente.Nombre) && cliente.Nombre.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido) && cliente.Apellido.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Documento) && cliente.Documento.Length < 3)
                return false;
            if (isNumeric(cliente.Celular) && cliente.Celular.Length < 10)
                return false;

            return true;
        }
        private bool isNumeric(string nro)
        {
            return nro.All(char.IsDigit);
        }
    }
}
