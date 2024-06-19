using System;


namespace Repository.Data.Productos
{
    public interface IProductosRepository
    {
        bool add(ProductosModel productosModel);
        bool update(ProductosModel productosModel);
        bool delete(int id);
        IEnumerable<ProductosModel> GetAll();
    }
}
