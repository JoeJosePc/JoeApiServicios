using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cibertec.Web.Handlers
{
    public class HandleCustomError : ExceptionFilterAttribute
    {
        private static readonly ILog log = 
            LogManager.GetLogger(typeof(HandleCustomError));
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is DivideByZeroException)
            {
                ///logica para este tipo error
            }
            if(context.Exception is NullReferenceException)
            {
                ///logica para este tipo error
            }
            //if (context.Exception is ProductoException)
            //{
            //    ///logica para este tipo error
            //}
            var errorMessage = $"Controller : {context.RouteData.Values["controller"].ToString()}, Action : {context.RouteData.Values["action"].ToString()}, Error : {context.Exception.Message.ToString()}";
            log.Error(errorMessage);            
            base.OnException(context);
        }
    }
}
