using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L02P2_2021GB650_2021CZ601.Models
{
    public class clientes
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo {  get; set; }
        public DateTime created_at { get; set; }
    }
}
