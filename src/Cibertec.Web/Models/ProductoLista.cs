using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Web.Models
{
    public class ProductoLista
    {
        public ProductoLista(IEnumerable<Producto> products, int total)
        {
            Products = products;
            Total = total;
        }
        public IEnumerable<Producto> Products { get; set; }
        public int Total { get; set; }

    }
}
