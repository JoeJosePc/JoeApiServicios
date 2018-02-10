using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Business;
using Cibertec.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Cibertec.Api.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cibertec.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoBusiness _productoBusiness;
        public ProductoController(IProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _productoBusiness.GetProductos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("GetProductos")]
        public IEnumerable<Producto> GetProductos([FromBody]ProductoQuery param)
        {
            return _productoBusiness.GetProductoPaginado(param);
        }

        /*METODO DE PRUEBA*/
        [HttpPost]
        [Route("GetProductos1")]
        public ProductoResponse GetProductos1([FromBody]ProductoQuery param)
        {
            return new ProductoResponse
            {
                Items = _productoBusiness.GetProductoPaginado(param)
            };
        }

        [HttpPost]
        [Route("Guardar")]
        public void InsertarProducto(Producto producto, ICollection<IFormFile> files)
        {
            if(files.Count > 0)
            {
                var archivo = files.First();
                var fileName = $"{DateTime.Now.ToString("ddMMyyyyhhmmss")}_{archivo.FileName}";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Archivos", fileName);

                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    archivo.CopyTo(stream);
                }

                producto.SetArchivo(fileName);
            }
            _productoBusiness.InsertProducto(producto);
        }

        [HttpPost]
        [Route("GetArchivo")]
        public FileStreamResult GetArchivo([FromBody]Descargar descargar)
        {
            if (string.IsNullOrWhiteSpace(descargar.archivo))
                throw new Exception("No existe el archivo");

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Archivos", descargar.archivo);

            FileStream fileStream = new FileStream(fullPath, FileMode.Open);

            return File(fileStream, "application/octet-stream", descargar.archivo);
        }
    }

    public class Descargar
    {
        public string archivo { get; set; }
    }
}
