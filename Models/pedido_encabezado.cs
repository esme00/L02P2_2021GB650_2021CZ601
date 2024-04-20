using System.ComponentModel.DataAnnotations;

namespace L02P2_2021GB650_2021CZ601.Models
{
    public class pedido_encabezado
    {
        [Key]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int cantidad_libros { get; set; }
        public decimal total { get; set; }
        public string estado {  get; set; }
    }
}
