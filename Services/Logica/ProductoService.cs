using Repository.Data.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ProductoService : IProductosRepository
    {
        private ProductosRepository productosRepository;
        public ProductoService(string connectionString)
        {
            productosRepository = new ProductosRepository(connectionString);
        }
        public bool add(ProductosModel productosModel)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductosModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool update(ProductosModel productosModel)
        {
            throw new NotImplementedException();
        }
        private bool validarDatos(ProductosModel productos)
        {
            if (productos == null)
                return false;
            if (string.IsNullOrEmpty(productos.Descripcion))
                return false;
            if (productos.Cantidad_Minima == null && productos.Cantidad_Minima<1)
                return false;
            if (productos.Cantidad_Stock == null)
                return false;
            if (productos.Precio_Compra == null)
                return false;
            if (productos.Precio_Venta == null)
                return false;
            if (string.IsNullOrEmpty(productos.Categoria))
                return false;
            if (string.IsNullOrEmpty(productos.Marca))
                return false;
            if (string.IsNullOrEmpty(productos.Estado))
                return false;
            if (productos.Precio_Compra <= 0 || productos.Precio_Venta <= 0)
                return false;

            return true;
        }
    }
}
