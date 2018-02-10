using Cibertec.Models;
using log4net;

namespace Cibertec.Business.Rules
{
    public class NuevoProducto : BaseProducto
    {
        private readonly ILog log = LogManager.GetLogger(typeof(NuevoProducto));

        public override bool IsApplicable(Producto producto)
        {
            if (producto.Tipo == 1) return true;
            return false;
        }

        internal override void CustomProcess(Producto producto)
        {
            log.Info("Process de Nuevo Producto.");
        }
    }
}
