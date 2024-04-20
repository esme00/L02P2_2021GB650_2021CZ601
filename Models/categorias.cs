using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L02P2_2021GB650_2021CZ601.Models
{
    public class categorias
    {
        [Key]
        public int id { get; set; }
        public string categoria { get; set; }
    }
}
