using System;
using System.Collections.Generic;
using Cibertec.Models;
using Cibertec.Repository;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Cibertec.DADapper
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(string connectionString) :
            base(connectionString)
        {

        }

        public IEnumerable<Producto> BuscarProducto(string texto)
        {
            var param = new
            {
                texto = texto
            };
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Producto>("dbo.BuscarProducto", param,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Producto> GetProductosPaginado(ProductoQuery query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                return con.Query<Producto>("dbo.GetProductoByParams",
                    query, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Producto>> GetProductosSinStock()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Producto>("dbo.GetProductoSinStock",
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
