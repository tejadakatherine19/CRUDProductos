using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudProductos.Models
{
    public class Contextoo: DbContext
    {
        public DbSet<Producto> Productos { get; set; }
    }
}