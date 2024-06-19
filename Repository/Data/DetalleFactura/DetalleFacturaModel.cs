using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.DetalleFactura
{
    public class DetalleFacturaModel
    {
        public int Id { get; set; }
        public int Id_Factura { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad_Producto { get; set; }
        public decimal Subtotal { get; set; }
    }
}
