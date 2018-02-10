using Cibertec.Repository;
using Cibertec.UnitOfWork;

namespace Cibertec.DADapper
{
    public class CibertecUnitOfWork : IUnitOfWork
    {
        public CibertecUnitOfWork(string connectionString)
        {
            productos = new ProductoRepository(connectionString);
        }
        public IProductoRepository productos { get; private set; }
    }
}
