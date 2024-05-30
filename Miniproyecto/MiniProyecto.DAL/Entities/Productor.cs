using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.DAL.Entities
{
    public class Productor
    {
        [Key]
        public int IDproductor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Empresa { get; set; }
        
      
    }
}
