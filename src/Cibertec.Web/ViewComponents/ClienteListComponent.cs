using Cibertec.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cibertec.Web.ViewComponents
{
    [ViewComponent(Name = "ClienteLista")]
    public class ClienteListComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(Producto producto)
        {
            return View("ClienteLista", producto);
        }
    }
}
