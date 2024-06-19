using Dapper;
using Repository.Data.ConfiguracionesDB;
using Repository.Data.DetalleFactura;
using Repository.Data.Sucursal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Factura
{
    public class FacturaRepository : IFacturaRepository
    {
        IDbConnection connection;

        public FacturaRepository(string connectionString)
        {
            connection = new ConnetionDB(connectionString).OpenConnection();
        }

        public bool add(FacturaModel facturaModel)
        {
            try
            {
                
                var queryFactura = @"INSERT INTO Factura(Id_Cliente, Id_Sucursal, Nro_Factura, Fecha_Hora, Total, Total_iva5, Total_iva10, Total_iva, Total_Letras)
                                        VALUES(@Id_Cliente, @Id_Sucursal, @Nro_Factura, @Fecha_Hora, @Total, @Total_iva5, @Total_iva10, @Total_iva, @Total_Letras);

                                        SELECT CAST(SCOPE_IDENTITY() as int);";

                var idFactura = connection.QuerySingle<int>(queryFactura, new
                {
                    facturaModel.Id_Cliente,
                    facturaModel.Id_Sucursal,
                    facturaModel.Nro_Factura,
                    facturaModel.Fecha_Hora,
                    facturaModel.Total,
                    facturaModel.Total_iva5,
                    facturaModel.Total_iva10,
                    facturaModel.Total_iva,
                    facturaModel.Total_Letras
                });

                foreach (var detalle in facturaModel.detalleFactura)
                {
                    var queryDetalle = @"INSERT INTO DetalleFactura(Id_Factura, Id_Producto, Cantidad_Producto, Subtotal)
                                            VALUES(@Id_Factura, @Id_Producto, @Cantidad_Producto, @Subtotal);";
                    connection.Execute(queryDetalle, new
                    {
                        Id_Factura = idFactura,
                        detalle.Id_Producto,
                        detalle.Cantidad_Producto,
                        detalle.Subtotal
                    });
                }

                return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(int id)
        {
            try
            {
                    connection.Execute("DELETE FROM DetalleFactura WHERE Id_Factura = @Id", new { Id = id });
                    connection.Execute("DELETE FROM Factura WHERE Id = @Id", new { Id = id });
                    return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            try
            {
                var facturaDictionary = new Dictionary<int, FacturaModel>();
                var query = @"SELECT
                            f.Id, f.Id_Cliente, f.Id_Sucursal, f.Nro_Factura, f.Fecha_Hora, f.Total, f.Total_iva5, f.Total_iva10, f.Total_iva, f.Total_Letras,
                            d.Id, d.Id_Factura, d.Id_Producto, d.Cantidad_Producto, d.Subtotal
                            FROM Factura f
                            LEFT JOIN DetalleFactura d ON f.Id = d.Id_Factura";

                var facturas = connection.Query<FacturaModel, DetalleFacturaModel, FacturaModel>(query, (factura, detalle) =>
                {
                    if (!facturaDictionary.TryGetValue(factura.Id, out var currentFactura))
                    {
                        currentFactura = factura;
                        currentFactura.detalleFactura = new List<DetalleFacturaModel>();
                        facturaDictionary.Add(currentFactura.Id, currentFactura);
                    }

                    if (detalle != null)
                    {
                        currentFactura.detalleFactura.Add(detalle);
                    }

                    return currentFactura;
                }, splitOn: "Id").Distinct().ToList();

                return facturas;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacturaModel getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(FacturaModel facturaModel)
        {
            try
            {
               
                var queryFactura = @"UPDATE Factura SET
                                    Id_Cliente = @Id_Cliente,
                                    Id_Sucursal = @Id_Sucursal,
                                    Nro_Factura = @Nro_Factura,
                                    Fecha_Hora = @Fecha_Hora,
                                    Total = @Total,
                                    Total_iva5 = @Total_iva5,
                                    Total_iva10 = @Total_iva10,
                                    Total_iva = @Total_iva,
                                    Total_Letras = @Total_Letras
                                    WHERE Id = @Id;";

                connection.Execute(queryFactura, facturaModel);

                foreach (var detalle in facturaModel.detalleFactura)
                {
                    var queryDetalle = @"UPDATE DetalleFactura SET
                                        Id_Producto = @Id_Producto,
                                        Cantidad_Producto = @Cantidad_Producto,
                                        Subtotal = @Subtotal
                                        WHERE Id = @Id;";
                    connection.Execute(queryDetalle, detalle);
                }

                return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
