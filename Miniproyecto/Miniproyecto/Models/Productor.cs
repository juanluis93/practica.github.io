using System.ComponentModel.DataAnnotations;

namespace Miniproyecto.Models
{
    public class ProductorModel
    {
        [Key]
        public int IDproductor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
         public string Empresa { get; set; }
    }
}
