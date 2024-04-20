using L02P2_2021GB650_2021CZ601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L02P2_2021GB650_2021CZ601.Controllers
{
    public class librosController : Controller
    {
        public IActionResult Index()
        {
            var listaAutores = (from m in _libreriaContext.autores
                                 select m).ToList();
            ViewData["listadodeautores"] = new SelectList(listaAutores, "id", "autor");

            var listaCat = (from m in _libreriaContext.categorias
                                select m).ToList();
            ViewData["listadodecategoria"] = new SelectList(listaCat, "id", "categoria");

            var listadodeequipo = (from e in _equiposContext.equipos
                                   join m in _equiposContext.marcas on e.marca_id equals m.marca_id
                                   select new
                                   {
                                       nombre = e.nombre,
                                       descripcion = e.descripcion,
                                       marca_id = e.marca_id,
                                       marca_nombre = m.nombre_marca
                                   }).ToList();
            ViewData["listadodeequipo"] = listadodeequipo;
            return View();
        }
        public IActionResult CrearLibros(libros nuevoLibro)
        {
            _libreriaContext.Add(nuevoLibro);
            _libreriaContext.SaveChanges();

            return RedirectToAction("Index");
        }



        private readonly libreriaContext _libreriaContext;
        public librosController(libreriaContext libreriaContext)
        {
            _libreriaContext = libreriaContext;
        }

    }
}
