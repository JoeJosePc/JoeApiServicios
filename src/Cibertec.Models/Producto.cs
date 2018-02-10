using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cibertec.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo Descripcion es Obligatorio")] 
        [StringLength(10,ErrorMessage ="Debe tener 10 caracteres como maximo")]       
        public string Descripcion { get; set; }

        [Required]
        public int StockMinimo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string Archivo { get; set; }

        public void SetArchivo(string archivo)
        {
            Archivo = archivo;
        }
      
        [Computed]
        public int Total { get; set; }

        [Computed]
        public int Tipo { get; set; }

        [Computed]
        public ICollection<IFormFile> files { get; set; }
    }
}
