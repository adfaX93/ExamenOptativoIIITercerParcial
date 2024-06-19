using Dapper;
using Repository.Data.Cliente;
using Repository.Data.ConfiguracionesDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Productos
{
    public class ProductosRepository : IProductosRepository
    {
        IDbConnection connection;
        public ProductosRepository(string connectionString)
        {
            connection = new ConnetionDB(connectionString).OpenConnection();
        }

        public bool add(ProductosModel productosModel)
        {
            try
            {
                connection.Execute("INSERT INTO Productos(Descripcion, Cantidad_Minima, Cantidad_Stock, Precio_Compra, Precio_Venta, Categoria, Marca, Estado) " +
                           "VALUES (@Descripcion, @Cantidad_Minima, @Cantidad_Stock, @Precio_Compra, @Precio_Venta, @Categoria, @Marca, @Estado)", productosModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Productos WHERE Id = {id}");
            return true;
        }

        public IEnumerable<ProductosModel> GetAll()
        {
            return connection.Query<ProductosModel>("SELECT * FROM Productos");
        }

        public bool update(ProductosModel productosModel)
        {
            try
            {
                connection.Execute("UPDATE Productos SET " +
                           "Descripcion = @Descripcion, " +
                           "Cantidad_Minima = @Cantidad_Minima, " +
                           "Cantidad_Stock = @Cantidad_Stock, " +
                           "Precio_Compra = @Precio_Compra, " +
                           "Precio_Venta = @Precio_Venta, " +
                           "Categoria = @Categoria, " +
                           "Marca = @Marca " +
                           "Estado = @Estado " +
                           "WHERE Id = @Id", productosModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
