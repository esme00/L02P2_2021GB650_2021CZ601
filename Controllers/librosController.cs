using L02P2_2021GB650_2021CZ601.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P2_2021GB650_2021CZ601.Controllers
{
    public class librosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CrearEquipos(libros nuevoLibro)
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
