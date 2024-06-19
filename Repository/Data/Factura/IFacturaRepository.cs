using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Factura
{
    public interface IFacturaRepository
    {
        bool add(FacturaModel factura);
        bool update(FacturaModel factura);
        bool delete(int id);
        FacturaModel getById(int id);
        IEnumerable<FacturaModel> GetAll();
    }
}
