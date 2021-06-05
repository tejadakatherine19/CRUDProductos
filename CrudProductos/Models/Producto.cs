using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudProductos.Models
{
    public class Producto
    {
        //Campos requeridos.
       
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre de producto es requerido")]
        public string producto { get; set; }

 [Required(ErrorMessage = "La descripcion de producto es requerido")]
        public string descripcion { get; set; }

        //[Range=(0,100, ErrorMessage="Ingrese un precio dentro del rango de 0 y 10")]
        [Required(ErrorMessage = "El precio de producto es requerido")]
        public double precio { get; set; }

       
    }
}