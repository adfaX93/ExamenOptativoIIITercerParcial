using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Productos
{
    public class ProductosModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_Minima { get; set; }
        public int Cantidad_Stock { get; set; }
        public int Precio_Compra { get; set; }
        public int Precio_Venta { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }
    }
}
