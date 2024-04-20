using System.ComponentModel.DataAnnotations;

namespace L02P2_2021GB650_2021CZ601.Models
{
    public class comentarios_libros
    {
        [Key]
        public int id { get; set; }
        public int id_libro { get; set; }
        public string comentarios { get; set; }
        public string usuario { get; set; }
        public DateTime created_ad { get; set; }
    }
}
