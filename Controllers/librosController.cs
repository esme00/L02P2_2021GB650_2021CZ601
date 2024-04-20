using L02P2_2021GB650_2021CZ601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Firebase.Auth;
using Firebase.Storage;
using L02P2_2021GB650_2021CZ601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


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

            var listadodeequipo = (from e in _libreriaContext.libros
                                   join m in _libreriaContext.autores on e.id_autor equals m.id
                                   join z in _libreriaContext.categorias on e.id_categoria equals z.id
                                   select new
                                   {
                                       id = e.id,
                                       nombre = e.nombre,
                                       descripcion = e.descripcion,
                                       precio = e.precio,
                                       autor = m.id,
                                       categoria = z.id
                                   }).ToList();
            ViewData["listadodeequipo"] = listadodeequipo;
            return View();
        }
        public async Task<IActionResult> CrearLibros(libros nuevoLibro, IFormFile archivo)
        {
            _libreriaContext.Add(nuevoLibro);
            _libreriaContext.SaveChanges();

            Stream archivoSubir = archivo.OpenReadStream();
            string urlImagen = await SubirImagenAFirebase(archivoSubir, archivo.FileName);

            // Establecer la URL de la imagen en el nuevo libro
            nuevoLibro.url_imagen = urlImagen;
            _libreriaContext.SaveChanges();


            return RedirectToAction("Index");
        }

        public async Task<string> SubirImagenAFirebase(Stream archivoSubir, string nombreArchivo)
        {
            string email = "jorgefranciscocz@gmail.com";
            string clave = "ContraseñaXDXD";
            string ruta = "desarolloweb-7ffb8.appspot.com";
            string apikey = "AIzaSyBbIwF8pmsda6lLtldYsro7e_Aa_SCNGq0";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(apikey));
            var autentificar = await auth.SignInWithEmailAndPasswordAsync(email, clave);
            var cancellation = new CancellationTokenSource();
            var tokenuser = autentificar.FirebaseToken;

            var cargararchivo = new FirebaseStorage(ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(tokenuser),
                    ThrowOnCancel = true
                }
            ).Child("libros")
            .Child(nombreArchivo)
            .PutAsync(archivoSubir, cancellation.Token);

            var urlcarga = await cargararchivo;

            return urlcarga;
        }

   
        // GET: autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _libreriaContext.libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        // POST: autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libros = await _libreriaContext.libros.FindAsync(id);
            if (libros != null)
            {
                _libreriaContext.libros.Remove(libros);
            }

            await _libreriaContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool autoresExists(int id)
        {
            return _libreriaContext.libros.Any(e => e.id == id);
        }



        private readonly libreriaContext _libreriaContext;
        public librosController(libreriaContext libreriaContext)
        {
            _libreriaContext = libreriaContext;
        }

    }
}
