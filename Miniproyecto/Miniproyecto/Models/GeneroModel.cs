using System.ComponentModel.DataAnnotations;

namespace MiniProyecto.Web.Models
{
    public class GeneroModel
    {
        [Key]
        public int IDgenero { get; set; }
        public string Tipo { get; set; }

    }
}
