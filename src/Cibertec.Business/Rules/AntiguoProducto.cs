using Cibertec.Models;
using log4net;

namespace Cibertec.Business.Rules
{
    public class AntiguoProducto : BaseProducto
    {
        private readonly ILog log = LogManager.GetLogger(typeof(AntiguoProducto));
        public override bool IsApplicable(Producto producto)
        {
            if (producto.Tipo == 0) return true;
            return false;
        }

        internal override void CustomProcess(Producto producto)
        {
            log.Info("Process de Antiguo Producto.");
        }
        public override void ProcessInicial()
        {
            log.Info("Inicio para Antiguo Productooooooooooo");
        }
    }
}
