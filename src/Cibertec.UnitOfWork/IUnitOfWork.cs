using Cibertec.Repository;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductoRepository productos { get; }
    }
}
