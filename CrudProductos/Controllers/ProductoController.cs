using CrudProductos.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudProductos.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create_Update(int idProd = 0)
        {
            if (idProd > 0)
            {
                using (var context = new Contextoo())
                {
                    var data = context.Productos.Where(x => x.id == idProd).FirstOrDefault();
                    return View(data);
                }
            }
            else
            {
                Producto model = new Producto();
                return View(model);
            }
            
        }
        [HttpPost]

        public ActionResult Create_Update(Producto model)
        {

           

            if (ModelState.IsValid)
            {

                var IsNew = model.id == 0 ? true : false;

                if (IsNew)
                {
                    using (var cont = new Contextoo())
                    {
                        cont.Productos.Add(model);
                        cont.SaveChanges();
                    }
                }
                else
                {
                    using (var cont = new Contextoo())
                    {
                        var data = cont.Productos.Where(x => x.id == model.id).FirstOrDefault();
                        data.producto = model.producto;
                        data.descripcion = model.descripcion;
                        data.precio = model.precio;


                        
                        cont.SaveChanges();
                    }
                }

               
                return View("Correcto");
            }
            else
            {
                return View(model);
            }




        }

        public ActionResult Mostrar()
        {
            using (var cont = new Contextoo())
            {
                var data = cont.Productos.ToList();
                ViewBag.datos = data;

                return View();
            }
        }

        public ActionResult Delete(int idProd)
        {
            using (var cont = new Contextoo())
            {
                var data = cont.Productos.Where(x => x.id == idProd).FirstOrDefault();
                cont.Productos.Remove(data);
                cont.SaveChanges();

            }
            //en caso de cargar datos y luego la vista se usa REDIRECT
            return RedirectToAction("Mostrar");

        }



        public ActionResult PDF()
        {
            using (var cont = new Contextoo())
            {
                var data = cont.Productos.ToList();
                ViewBag.datos = data;
            }

            return new ViewAsPdf("PDF")
            {
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = new Rotativa.Options.Margins(10, 20, 10, 20),
                FileName = "ListaProductos.pdf"

            };
        }
    }
}