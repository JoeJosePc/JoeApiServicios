using Cibertec.Models;

namespace Cibertec.Business.Rules
{
    public interface IRule
    {
        bool IsApplicable(Producto producto);

        void Process(Producto producto);
    }
}
