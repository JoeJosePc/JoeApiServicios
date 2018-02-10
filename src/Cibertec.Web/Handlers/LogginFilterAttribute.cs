using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cibertec.Web.Handlers
{
    public class LogginFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog log =
          LogManager.GetLogger(typeof(LogginFilterAttribute));
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var message = $"Inicia ejecucion de : controller {context.Controller.ToString()}, Action: {context.ActionDescriptor.DisplayName}, hora de inicio: {DateTime.Now.ToString()}";
            log.Info(message);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var message = $"Inicia ejecucion de : controller {context.Controller.ToString()}, Action: {context.ActionDescriptor.DisplayName}, hora de inicio: {DateTime.Now.ToString()}";
            log.Info(message);
        }
    }
}
