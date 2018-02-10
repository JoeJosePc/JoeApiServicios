using Cibertec.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cibertec.Repository
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductosSinStock();
        IEnumerable<Producto> BuscarProducto(string texto);
        IEnumerable<Producto> GetProductosPaginado(ProductoQuery query);
    }
}
