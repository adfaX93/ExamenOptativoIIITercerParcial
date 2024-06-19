using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Sucursal
{
    internal interface ISucursalRepository
    {
        bool add(SucursalModel sucursalModel);
        bool update(SucursalModel sucursalModel);
        bool delete(int id);
        IEnumerable<SucursalModel> GetAll();
    }
}
