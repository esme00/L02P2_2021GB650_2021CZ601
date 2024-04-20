using Microsoft.EntityFrameworkCore;


namespace L02P2_2021GB650_2021CZ601.Models
{
    public class libreriaContext : DbContext
    {
        public libreriaContext(DbContextOptions<libreriaContext> options) : base(options)
        {

        }
    }
    public DbSet<autores> autores { get; set; }
    public DbSet<categorias> categorias { get; set; }
    public DbSet<clientes> clientes { get; set; }
    public DbSet<comentarios_libros> comentarios_libros { get; set; }
    public DbSet<libros> libros { get; set; }  /*  PRINCIPA*/
    public DbSet<pedido_detalle> pedido_detalle { get; set; }
    public DbSet<pedido_encabezado> pedido_encabezado { get; set; }
}
