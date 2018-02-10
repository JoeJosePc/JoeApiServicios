using Cibertec.Business.Rules;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Cibertec.Business
{
    public interface IProductoBusiness
    {
        IEnumerable<Producto> GetProductos();
        Task<int> GetProductoSinStock();
        int InsertProducto(Producto producto);
        int DeleteProducto(Producto producto);
        Producto GetProducto(int id);
        int UpdateProducto(Producto producto);
        IEnumerable<Producto> GetProductoByDesc(string texto);
        IEnumerable<Producto> GetProductoPaginado(ProductoQuery query);
        ////mas metodos 
    }
    public class ProductoBusiness : IProductoBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IEnumerable<IRule> _rules;
        public ProductoBusiness(IUnitOfWork unitOfWork,
            IEnumerable<IRule> rules)
        {
            _rules = rules;
            _unitofWork = unitOfWork;
        }

        public ProductoBusiness(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IEnumerable<Producto> GetProductos()
        {
            return _unitofWork.productos.GetList();
        }
        public async Task<int> GetProductoSinStock()
        {
            var lista = await _unitofWork.productos.GetProductosSinStock();
            return lista.Count();
        }

        public int InsertProducto(Producto producto)
        {
            //var clase = _rules.FirstOrDefault(x => x.IsApplicable(producto));
            //clase.Process(producto);

            return _unitofWork.productos.Insert(producto);
        }

        public int DeleteProducto(Producto producto)
        {
            return _unitofWork.productos.Delete(producto);
        }

        public Producto GetProducto(int id)
        {
            return _unitofWork.productos.GetById(id);
        }

        public int UpdateProducto(Producto producto)
        {
            return _unitofWork.productos.Update(producto);
        }

        public IEnumerable<Producto> GetProductoByDesc(string texto)
        {
            return _unitofWork.productos.BuscarProducto(texto);
        }

        public IEnumerable<Producto> GetProductoPaginado(ProductoQuery query)
        {
            return _unitofWork.productos.GetProductosPaginado(query);
        }
    }
}
