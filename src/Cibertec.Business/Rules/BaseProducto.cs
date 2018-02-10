using Cibertec.Models;
using log4net;

namespace Cibertec.Business.Rules
{
    public abstract class BaseProducto : IRule
    {
        private readonly ILog log = LogManager.GetLogger(typeof(BaseProducto));
        public abstract bool IsApplicable(Producto producto);

        public void Process(Producto producto)
        {
            ProcessInicial();
            CustomProcess(producto);
            log.Info("Fin - Process Common para todas las estrategias");
        }

        internal abstract void CustomProcess(Producto producto);

        public virtual void ProcessInicial()
        {
            log.Info("Inicio - Process Common para todas las estrategias");
        }
    }
}
