using Repository.Data.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class FacturaService : IFacturaRepository
    {
        private FacturaRepository facturaRepository;
        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }
        public bool add(FacturaModel factura)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FacturaModel getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(FacturaModel factura)
        {
            throw new NotImplementedException();
        }
        private bool validarDatos(FacturaModel facturaModel)
        {
            if (facturaModel == null)
                return false;
            if (!EsNroFacturaValido(facturaModel.Nro_Factura))
                return false;
            if (!(facturaModel.Total >=0 && facturaModel.Total_iva5 >= 0 && facturaModel.Total_iva10 >= 0 && facturaModel.Total_iva >= 0))
                return false;
            if (string.IsNullOrEmpty(facturaModel.Total_Letras) || facturaModel.Total_Letras.Length < 6)
                return false;
            if (isNumeric(cliente.Celular) && cliente.Celular.Length < 10)
                return false;

            return true;
        }
        private bool EsNroFacturaValido(string nroFactura)
        {
            string pattern = @"^\d{3}-\d{3}-\d{6}$";
            return Regex.IsMatch(nroFactura, pattern);
        }
    }
}
