using Repository.Data.DetalleFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Factura
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Sucursal { get; set; }
        public string Nro_Factura { get; set; }
        public string Fecha_Hora { get; set; }
        public double Total { get; set; }
        public double Total_iva5 { get; set; }
        public double Total_iva10 { get; set; }
        public double Total_iva { get; set; }
        public string Total_Letras { get; set; }
        public List<DetalleFacturaModel> detalleFactura { get; set; }
    }
}
